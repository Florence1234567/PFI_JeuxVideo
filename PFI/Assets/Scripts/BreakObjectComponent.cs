using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObjectComponent : MonoBehaviour
{
    [SerializeField] bool IsFoundation = false; // Never breaks object if set to true (still reduces structure health)
    [SerializeField] bool IsResilient = false; // Breaks only if structure health is less than half 

    [SerializeField] float StructureDamage = 15; // Damage dealt when object is broken
    [SerializeField] float DestroyTime = 10f; // Time before object vanishes after being broken

    private bool isDead = false;
    private float timeSinceDeath = 0f;

    HealthComponent hpComponent;


    void Start()
    {
        hpComponent = gameObject.GetComponentInParent<HealthComponent>();

        if (hpComponent == null)
            hpComponent = gameObject.GetComponent<HealthComponent>();
    }

    private void Update()
    {
        if (isDead)
            timeSinceDeath += Time.deltaTime;

        if (timeSinceDeath > DestroyTime)
            Destroy(gameObject);
    }


    public void OnCollisionEnter(Collision collision)
    {
        // if object is resilient, check if structure health is below half 
        bool resilienceCheck = (IsResilient && hpComponent.GetHealth() < (hpComponent.GetMaxHealth() / 2) || !IsResilient) ? true : false;

        if (collision.gameObject.GetComponent<ExplodeComponent>() != null && !IsFoundation && !isDead && resilienceCheck)
        {
            isDead = true;

            Rigidbody rb = GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;


                if (hpComponent != null)
                {
                    hpComponent.ReduceHealth(StructureDamage);
                    Debug.Log(hpComponent.GetHealth());
                }
                    
            }
                
        }
    }
}
