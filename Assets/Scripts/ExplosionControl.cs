using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionControl : MonoBehaviour
{
    private Animator _compAnimator;
    public float TimeToDestroy;

    void Awake()
    {
        _compAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        Invoke("DestroyObject", TimeToDestroy);
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}