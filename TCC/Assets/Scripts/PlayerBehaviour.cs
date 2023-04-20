using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
	[SerializeField] HealthbarManager healthbarManager;
	[SerializeField] ManabarManager manabarManager;
	[SerializeField] Animator animator;

	public void TakeDamage(float damage)
	{
		animator.SetTrigger("TakeDamage");
		healthbarManager.TakeDamage(damage);

		if (healthbarManager.isDead())
			Die();
	}

	public void Die()
	{
		animator.SetTrigger("Die");
	}

	public void AfterDie()
	{
		gameObject.SetActive(false);
	}
}
