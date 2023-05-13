using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeComponent : MonoBehaviour
{
    [SerializeField] GameObject ExplosionEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    public void Explode()
    {
        GameObject Explosion = ObjectPoolComponent.ObjectPoolInstance.GetPooledObject(ExplosionEffect);
        Explosion.transform.position = transform.position;
        Explosion.transform.rotation = transform.rotation;

        ExplosionEffect.SetActive(true);
    }
}
