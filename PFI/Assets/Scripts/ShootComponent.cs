using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(GunManager))]

public class ShootComponent : MonoBehaviour
{
    [SerializeField] GameObject Bullet;
    [SerializeField] InputAction shootAction;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] float cooldown = 2;

    private GunManager gunManager
    float bulletCount;
    float elapsedTime = 0;

    // Start is called before the first frame update
    void Awake()
    {

        source.clip = clip;
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
            for (int i = 0; i < bulletCount; i++)
                Shoot();
    }

    public void Shoot()
    {
        GameObject bullet = ObjectPoolComponent.ObjectPoolinstance.GetPooledObject(Bullet);

        bullet.transform.SetPositionAndRotation(
            new Vector3(transform.position.x, transform.position.y + 2, transform.position.z),
            transform.rotation);
        bullet.SetActive(true);

        source.Stop();
        source.Play();

        elapsedTime = 0;
    }
}
