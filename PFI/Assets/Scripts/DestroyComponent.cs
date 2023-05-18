using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComponent : MonoBehaviour
{
    [SerializeField] float lifeSpan = 5;

    float initialTime;

    private void OnEnable()
    {
        initialTime = Time.time;
    }

    void Update()
    {
        if (Time.time > initialTime + lifeSpan)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
