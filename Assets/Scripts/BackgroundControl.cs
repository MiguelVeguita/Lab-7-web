using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControl : MonoBehaviour
{
    private Rigidbody2D _compRigidbody;
    public float backgroundSpeed;

    void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.y <= -10)
        {
            Vector3 newPosition = new Vector3(transform.position.x, 10, transform.position.z);
            transform.position = newPosition;
        }
    }

    void FixedUpdate()
    {
        _compRigidbody.velocity = new Vector2(0, backgroundSpeed);
    }
}