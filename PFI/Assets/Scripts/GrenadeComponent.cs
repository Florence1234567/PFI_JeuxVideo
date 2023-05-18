using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeComponent : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {

        Vector3 flingForceVector = transform.forward * 35f;
        rb.AddForce(flingForceVector, ForceMode.Impulse);
    }

    void Update()
    {
        
    }
    

}
