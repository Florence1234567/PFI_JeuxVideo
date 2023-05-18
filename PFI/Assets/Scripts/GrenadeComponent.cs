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
        rb.AddForce(transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
