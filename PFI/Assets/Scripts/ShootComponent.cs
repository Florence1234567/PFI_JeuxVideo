using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootComponent : MonoBehaviour
{
    //Source pour animation.
    //https://www.youtube.com/watch?v=Sqb-Ue7wpsI

    [SerializeField] GameObject grenade;
    [SerializeField] InputAction shootAction;
    //[SerializeField] AudioSource source;
    //[SerializeField] AudioClip clip;
    [SerializeField] float cooldown = 2;
    
    Animator animator;

    float elapsedTime = 0;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();

        //source.clip = clip;
    }

    private void OnEnable()
    {
        shootAction.Enable();
    }

    private void OnDisable()
    {
        shootAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (shootAction.IsPressed() && elapsedTime >= cooldown)
            Shoot();
    }

    public void Shoot()
    {
        animator.SetTrigger("Fire");

        GameObject bullet = ObjectPoolComponent.ObjectPoolinstance.GetPooledObject(grenade);

        bullet.transform.SetPositionAndRotation(
            new Vector3(transform.position.x, transform.position.y, transform.position.z),
            transform.rotation);
        bullet.SetActive(true);

        Debug.Log(bullet.transform.position);
        Debug.Log(transform.position);

        //source.Stop();
        //source.Play();

        elapsedTime = 0;
    }
}
