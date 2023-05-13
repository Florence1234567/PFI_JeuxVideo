using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyComponent : MonoBehaviour
{
    Coroutine LaunchCoroutine;

    Vector3 landingPos;

    float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(Vector3 landingPos)
    { 
        this.landingPos = landingPos;
        LaunchCoroutine = StartCoroutine("Launch");
    }

    IEnumerator Launch()
    {
        //Calculate parabola.

        for(int i = 0; i < 10; i++)
        {
            //Move character.
            yield return new WaitForSeconds(1f);
        }
    }
}
