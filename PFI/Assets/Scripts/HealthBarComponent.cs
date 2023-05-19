using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarComponent : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthBar(float health, float maxHealth)
    {
        healthBar.fillAmount = health / maxHealth;
    }

    public void RefillHealthBar()
    {
        healthBar.fillAmount = 100;
    }
}
