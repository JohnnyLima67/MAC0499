using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableBehaviour : MonoBehaviour
{
	[SerializeField] HealthManager healthbarManager;
    [SerializeField] EntityAnimator animator;
    [SerializeField] PlayerDirection calcPlayerDir;
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
            StartKnockback();
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
                StartKnockback();
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
                StartKnockback();
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

    private void StartKnockback()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;

        Vector2 force = Vector2.zero;
        if (player.gameObject == this.gameObject)
            force = new Vector2(-knockbackForceX * Mathf.Sign(thisFlippable.transform.rotation.y),
                                        knockbackForceY);
        else
        {
            float xForceValue = -knockbackForceX *
                calcPlayerDir.WhichPlayerDirection(player) *
                Mathf.Sign(thisFlippable.transform.rotation.y);

            force = new Vector2(xForceValue, knockbackForceY);
        }

        knockbackBehaviour.ApplyKnockback(force, knockbackDuration);
    }
}
