using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbarManager : HealthManager
{
    public Image healthBar;

    // Start is called before the first frame update
    public override void Start()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.fillAmount = health / maxHealth;
    }

    public override void TakeDamage(float damage)
    {
        if (Mathf.Sign(passedTime) == -1)
        {
            passedTime = +0.0f;
            if (damage > 0)
            {
                health = Mathf.Max(health - damage, 0);
                healthBar.fillAmount = health / maxHealth;
                StartCoroutine(animator.PlayTakeDamage());
            }
        }
    }

    public override void Heal(float healing)
    {
        if (healing > 0)
        {
            health = Mathf.Clamp(health + healing, 0, maxHealth);
            healthBar.fillAmount = health / maxHealth;
        }
    }
}
