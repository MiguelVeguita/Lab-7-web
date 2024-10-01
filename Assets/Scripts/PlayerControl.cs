using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D _compRigidbody;
    public float speedX;
    public float speedY;
    public GameObject bulletPrefab;
    private float horizontal;
    private float vertical;
    public AudioSource gunshotSound;
    public int lives = 3;
    public GameObject explosionPrefab;
    public GameManagerControlSS gameManager;

    void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if (Time.timeScale == 1)
            {
                Instantiate(bulletPrefab, transform.position, transform.rotation);
                gunshotSound.Play();
            }
        }
    }

    void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector2(horizontal*speedX, vertical*speedY);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BulletEnemy" || collision.gameObject.tag == "Enemy")
        {
            gameManager.UpdateLives();
            DestroyPlayer();
        }
    }

    void DestroyPlayer()
    {
        if (gameManager.lives <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            gameManager.PlayerDefeated();
        }
    }
}