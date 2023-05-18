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
        
    }

    void Update()
    {
        Vector3 flingForceVector = transform.forward * 5f;
        rb.AddForce(flingForceVector, ForceMode.Impulse);
    }

}
