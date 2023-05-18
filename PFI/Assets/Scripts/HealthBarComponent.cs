using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarComponent : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image healthBar;

    float maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthBar(float health)
    {
        healthBar.fillAmount = health / maxHealth;
    }

    public void ActivateHealthBar()
    {
        healthBar.fillAmount = maxHealth;
    }
}
