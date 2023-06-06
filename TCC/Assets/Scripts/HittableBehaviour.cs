using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableBehaviour : MonoBehaviour
{
	[SerializeField] HealthManager healthbarManager;
    [SerializeField] EntityAnimator animator;
    [SerializeField] Collider2D[] entityColliders;
    [SerializeField] bool isBounceable = true;

    private bool died = false;

	public void TakeDamage(float damage)
	{
        if (died)
            return;

		healthbarManager.TakeDamage(damage);

		if (healthbarManager.isDead())
			Die();
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
        return isBounceable;
    }
}
