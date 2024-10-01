using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float bulletSpeed;
    private Rigidbody2D _compRigidbody;

    void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector2(0, bulletSpeed * 1);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Up")
        {
            Destroy(this.gameObject);
        }
    }
}