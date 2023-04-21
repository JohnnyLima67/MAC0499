using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] protected EntityAnimator animator;
    [SerializeField] protected float maxHealth = 200f;
    [SerializeField] protected float health = 200f;
    [SerializeField] protected float damageInterval = 0.5f;

    protected float passedTime = -1.0f;

    // Start is called before the first frame update
    public virtual void Start()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    public virtual void FixedUpdate()
    {
        if (Mathf.Sign(passedTime) == 1)
        {
            passedTime += Time.deltaTime;

            if (passedTime >= damageInterval)
                passedTime = -1.0f;
        }
    }

    public virtual void TakeDamage(float damage)
    {
        if (Mathf.Sign(passedTime) == -1)
        {
            passedTime = +0.0f;
            if (damage > 0)
            {
                health = Mathf.Max(health - damage, 0);
                StartCoroutine(animator.PlayTakeDamage());
            }
        }
    }

    public virtual void Heal(float healing)
    {
        if (healing > 0)
        {
            health = Mathf.Clamp(health + healing, 0, maxHealth);
        }
    }

    public virtual bool isDead()
    {
        if (health <= 0.01)
            return true;
        else
            return false;
    }

    public virtual float GetDamageInterval()
    {
        return damageInterval;
    }
}
