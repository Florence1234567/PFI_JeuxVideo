using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeComponent : MonoBehaviour
{
    [SerializeField] Material transparent;

    public bool exploded = false;

    MeshRenderer GrenadeRenderer;
    Rigidbody Rigidbody;
    ParticleSystem Explosion;

    // Start is called before the first frame update
    void Awake()
    {
        GrenadeRenderer = GetComponentInChildren<MeshRenderer>();
        Explosion = GetComponentInChildren<ParticleSystem>();
        Rigidbody = GetComponent<Rigidbody>();
        Explosion.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(!exploded)
        {
            Explosion.Play();
            GrenadeRenderer.material = transparent;

            Rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;

            //exploded = true;
        }
    }
}
