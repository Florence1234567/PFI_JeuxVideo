using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class BreakObjectComponent : MonoBehaviour
{
    [SerializeField] private bool IsFoundation = false; // Never breaks object if set to true (still reduces structure health)
    [SerializeField] private bool IsResilient = false; // Breaks only if structure health is less than half 
    [SerializeField] private bool IsDamagingObject = false; // Object also breaks other objects it touches after its broken :) 

    [SerializeField] private float spinForce = 10f; // The force applied to spin the object
    [SerializeField] private float flingForce = 50f; // The force applied to fling the object
    [SerializeField] private Transform flingDirection;
    [SerializeField] private float flingTimer = .5f; //How long do we fling this object?

    [SerializeField] private float StructureDamage = 15; // Damage dealt when object is broken
    [SerializeField] private float DestroyTime = 10f; // Time before object vanishes after being broken

    private bool isDestroyed = false;
    private float timeSinceDeath = 0f;
    Rigidbody rb;

    HealthComponent hpComponent;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hpComponent = gameObject.GetComponentInParent<HealthComponent>();

        if (hpComponent == null)
            hpComponent = gameObject.GetComponent<HealthComponent>();
    }

    private void Update()
    {
        if (isDestroyed)
        {
            timeSinceDeath += Time.deltaTime;

            flingTimer -= Time.deltaTime;

            // Stop the fling after timer runs out :(((

            if (flingTimer <= 0f)
            {
                rb.velocity -= rb.velocity;
                rb.angularVelocity -= rb.angularVelocity;
                rb.velocity = new Vector3(0,-10,0);

            }
        }

        if (timeSinceDeath > DestroyTime)
            Destroy(gameObject);
    }


    public void OnCollisionEnter(Collision collision)
    {
        ExplodeComponent explodeComponent = collision.transform.GetComponent<ExplodeComponent>();


        if (collision.gameObject.GetComponent<ExplodeComponent>() != null && hpComponent != null && explodeComponent != null && explodeComponent.exploded == false)
        {
            explodeComponent.exploded = true;

            ObjectDestroyed(collision.gameObject);
        }
        
        if (IsDamagingObject && isDestroyed)
        {
            BreakObjectComponent breakObjectComponent = collision.transform.GetComponent<BreakObjectComponent>();

            if (breakObjectComponent)
            {
                breakObjectComponent.ObjectDestroyed(gameObject);
            }
        }
    }

    public void ObjectDestroyed(GameObject collidedObject)
    {
        hpComponent.ReduceHealth(StructureDamage); //Reduce global structure health because the object is broken
        Debug.Log(hpComponent.GetHealth());

        // if object is resilient, check if structure health is below half 
        bool resilienceCheck = (IsResilient && hpComponent.GetHealth() < (hpComponent.GetMaxHealth() / 2) || !IsResilient) ? true : false;

        if (!IsFoundation && !isDestroyed && resilienceCheck)
        {
            isDestroyed = true;


            if (rb != null)
            {
                rb.isKinematic = false;
                rb.useGravity = true;

                // FLING TIME YAY  :)))))

                // Spin
                Vector3 spinTorque = new Vector3(0f, spinForce, 0f);
                rb.AddTorque(spinTorque, ForceMode.Impulse);

                // Fling 
                Vector3 randomDirection = Random.insideUnitSphere.normalized;
                Vector3 flingForceVector = randomDirection * flingForce;
                rb.AddForce(flingForceVector, ForceMode.Impulse);

                /* turn object children into non kinematic rigidbodies
                Rigidbody[] rigidBodies = GetComponentsInChildren<Rigidbody>();

                foreach (Rigidbody rb in rigidBodies)
                {
                    rb.isKinematic = false;
                    rb.useGravity = true;
                }*/
            }
        }
    }
}
