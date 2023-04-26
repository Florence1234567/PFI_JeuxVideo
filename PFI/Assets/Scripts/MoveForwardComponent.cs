using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardComponent : MonoBehaviour
{
    float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * speed * Vector2.up);
    }
}
