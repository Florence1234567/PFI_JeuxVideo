using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeComponent : MonoBehaviour
{
    [SerializeField] Material transparent;

    public bool exploded = false;

    MeshRenderer GrenadeRenderer;
    ParticleSystem Explosion;

    // Start is called before the first frame update
    void Awake()
    {
        GrenadeRenderer = GetComponentInChildren<MeshRenderer>();
        Explosion = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        Explosion.Play();
        GrenadeRenderer.material = transparent;
    }
}
