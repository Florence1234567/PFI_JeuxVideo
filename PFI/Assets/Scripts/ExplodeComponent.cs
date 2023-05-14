using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeComponent : MonoBehaviour
{
    [SerializeField] GameObject ExplosionInPool;

    GameObject ExplosionEffect;

    // Start is called before the first frame update
    void Awake()
    {
        ExplosionEffect = ExplosionInPool;
        //ExplosionEffect = ObjectPoolComponent.ObjectPoolInstance.GetPooledObject(ExplosionInPool);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        transform.gameObject.SetActive(false);
        //ExplosionEffect.transform.position = collision.transform.position;
        ExplosionEffect.gameObject.SetActive(true);
    }
}
