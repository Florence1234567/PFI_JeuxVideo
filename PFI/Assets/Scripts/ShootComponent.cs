using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShootComponent : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] InputAction shootAction;
    //[SerializeField] AudioSource source;
    //[SerializeField] AudioClip clip;
    [SerializeField] float cooldown = 2;

    private Animator animator;

    float bulletCount;
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

        GameObject bullet = ObjectPoolComponent.ObjectPoolinstance.GetPooledObject(Bullet);

        bullet.transform.SetPositionAndRotation(
            new Vector3(transform.position.x, transform.position.y + 2, transform.position.z),
            transform.rotation);
        bullet.SetActive(true);

        //source.Stop();
        //source.Play();

        elapsedTime = 0;
    }
}
