using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindTurbineComponent : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 force = Vector3.right * 10f; 
        
        rb.AddForce(force, ForceMode.Force);
    }
}
