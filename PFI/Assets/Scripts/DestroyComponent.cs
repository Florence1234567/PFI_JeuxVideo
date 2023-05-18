using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComponent : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] float lifeSpan = 5;

    MeshRenderer GrenadeRenderer;

    float initialTime;

    private void OnEnable()
    {
        initialTime = Time.time;
    }

    void Awake()
    {
        GrenadeRenderer = GetComponentInChildren<MeshRenderer>();
    }

    void Update()
    {
        if (Time.time > initialTime + lifeSpan)
        {
            gameObject.SetActive(false);
            GrenadeRenderer.material = material;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
