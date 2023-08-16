using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableBehaviour : MonoBehaviour
{
	[SerializeField] HealthManager healthbarManager;
    [SerializeField] EntityAnimator animator;
    [SerializeField] Collider2D[] entityColliders;
    [SerializeField] bool isBounceable = true;
    [SerializeField] float weakSpotDmgMul = 5.0f;
    [SerializeField] KnockbackBehaviour knockbackBehaviour;
    [SerializeField] float knockbackForceX;
    [SerializeField] float knockbackForceY;
    [SerializeField] float knockbackDuration;
    [SerializeField] Transform thisFlippable;

    private bool died = false;

    public void TakeDamage(float damage)
	{
        if (died || !healthbarManager.CanTakeDamage())
            return;

        healthbarManager.TakeDamage(damage);

        if (healthbarManager.isDead())
            Die();
        else
        {
            StartCoroutine(animator.PlayTakeDamage());

            Vector2 force = new Vector2(-knockbackForceX * Mathf.Sign(thisFlippable.transform.rotation.y), knockbackForceY);
            knockbackBehaviour.ApplyKnockback(force, knockbackDuration);
        }
	}

	public void TakeDamage(float damage, bool hitWeakSpot)
	{
        if (died || !healthbarManager.CanTakeDamage())
            return;

        if (hitWeakSpot)
        {
            healthbarManager.TakeDamage(damage * weakSpotDmgMul);

            if (healthbarManager.isDead())
                Die();
            else
            {
                StartCoroutine(animator.PlayTakeCriticalDamage());
                Vector2 force = new Vector2(-knockbackForceX * Mathf.Sign(thisFlippable.transform.rotation.y), knockbackForceY);
                knockbackBehaviour.ApplyKnockback(force, knockbackDuration);
            }
        }
        else
        {
            healthbarManager.TakeDamage(damage);

            if (healthbarManager.isDead())
                Die();
            else
            {
                StartCoroutine(animator.PlayTakeDamage());
                Vector2 force = new Vector2(-knockbackForceX * Mathf.Sign(thisFlippable.transform.rotation.y), knockbackForceY);
                knockbackBehaviour.ApplyKnockback(force, knockbackDuration);
            }
        }
	}

	public void Die()
	{
        if (died)
            return;

        died = true;
        StartCoroutine(animator.PlayDie());
        foreach(Collider2D col in entityColliders)
        {
            col.enabled = false;
        }
	}

	public void AfterDie()
	{
		gameObject.SetActive(false);
	}

    public bool IsBounceable()
    {
        if(healthbarManager.isDead()) return false;
        return isBounceable;
    }
}
