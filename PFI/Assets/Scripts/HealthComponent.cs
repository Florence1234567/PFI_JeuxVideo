using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private float Health = 100;

    private float MaxHealth;

    private void Start()
    {
        MaxHealth = Health;
    }

    public float GetMaxHealth()
    {
        return MaxHealth;
    }

    public float GetHealth()
    {
        return Health;
    }

    // unused
    private void SetHealth(float amount)
    {
        Health = amount;
    }

    public void ReduceHealth(float amount)
    {
        Health -= amount;
    }

    // Update is called once per frame
    void Update()
    {
       if (Health <= 0)
        {

        }
    }
}
