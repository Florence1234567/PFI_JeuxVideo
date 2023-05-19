using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukeComponent : MonoBehaviour
{
    ParticleSystem Explosion;
    BreakObjectComponent BreakObjectComponent;
    bool explosionPlayed = false;

    // Start is called before the first frame update
    void Awake()
    {
        Explosion = GetComponentInChildren<ParticleSystem>();
        BreakObjectComponent = GetComponent<BreakObjectComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BreakObjectComponent.CheckIsDestroyed() && !explosionPlayed) 
        {
            Explosion.Play();
            explosionPlayed = true;
        }
    }
}
