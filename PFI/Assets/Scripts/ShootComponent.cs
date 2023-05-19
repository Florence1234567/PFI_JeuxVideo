using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ShootComponent : MonoBehaviour
{
    //Source pour animation.
    //https://www.youtube.com/watch?v=Sqb-Ue7wpsI

    [SerializeField] GameObject grenade;
    [SerializeField] InputAction shootAction;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip clip;
    [SerializeField] float cooldown = 2;

    ManageGrenadeCount manageCount;
    Animator animator;
    ManageLevel manageLevel;
    HealthBarComponent healthBar;

    float grenadeCount = 15;
    float elapsedTime = 0;

    // Start is called before the first frame update
    void Awake()
    {
        manageCount = GameObject.FindWithTag("ManageUI").GetComponent<ManageGrenadeCount>();
        manageLevel = GameObject.FindWithTag("ManageUI").GetComponent<ManageLevel>();
        healthBar = GameObject.FindWithTag("ManageUI").GetComponent<HealthBarComponent>();

        animator = GetComponent<Animator>();

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
        if (manageLevel.GetLevelCount() == 2)
        {
            grenadeCount = 2;
            healthBar.RefillHealthBar();
        }

        elapsedTime += Time.deltaTime;
        if (shootAction.IsPressed() && elapsedTime >= cooldown)
            Shoot();
    }

    public void Shoot()
    {
        source.Stop();
        source.Play();

        animator.SetTrigger("Fire");

        GameObject bullet = ObjectPoolComponent.ObjectPoolinstance.GetPooledObject(grenade);

        bullet.transform.position = new Vector3(transform.position.x, 2, transform.position.z);
        bullet.transform.rotation = transform.rotation;
        bullet.SetActive(true);

        grenadeCount--;
        elapsedTime = 0;

        manageCount.UpdateGrenadeCount(grenadeCount);
    }
}
