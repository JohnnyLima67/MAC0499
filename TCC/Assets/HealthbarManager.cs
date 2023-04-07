using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarManager : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 200f;
    public float health = 160f;

    // Start is called before the first frame update
    void Start()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.fillAmount = health / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(10);
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            health = Mathf.Max(health - damage, 0);
            healthBar.fillAmount = health / maxHealth;
        }
    }

    public void Heal(float healing)
    {
        if (healing > 0)
        {
            health = Mathf.Clamp(health + healing, 0, maxHealth);
            healthBar.fillAmount = health / maxHealth;
        }
    }
}
