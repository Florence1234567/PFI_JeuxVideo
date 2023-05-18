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
        rb.AddForce(Vector3.forward, ForceMode.Impulse);
    }

    private void Start()
    {
        Vector3 flingForceVector = transform.forward * 10f;
        rb.AddForce(flingForceVector, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
    

    }
}
