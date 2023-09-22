using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponBehaviour : MonoBehaviour
{
    [SerializeField] TarodevController.PlayerController playerController;
    [SerializeField] float damage;
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D attackUpCollider;
    [SerializeField] BoxCollider2D attackHorizontalCollider;
    [SerializeField] BoxCollider2D attackDownCollider;
    [SerializeField] PlayerWeaponColliderDetector colliderDetector;
	[SerializeField] AudioSource audioSource;
	[SerializeField] AudioClip attackSwooshSound;

    void Awake()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<TarodevController.PlayerController>();
    }

    public void TriggerHorizontalAttackAnimation()
    {
		audioSource.PlayOneShot(attackSwooshSound, 0.40f);
        animator.SetTrigger("AttackHorizontal");
    }

    public void TriggerDownAttackAnimation()
    {
		audioSource.PlayOneShot(attackSwooshSound, 0.40f);
        animator.SetTrigger("AttackDown");
    }

    public void TriggerUpAttackAnimation()
    {
		audioSource.PlayOneShot(attackSwooshSound, 0.40f);
        animator.SetTrigger("AttackUp");
    }

    GameObject[] CheckForWeakSpots(Collider2D[] col)
    {
        GameObject[] weakSpotsReached = new GameObject[col.Length];

        int i = 0;
        foreach(Collider2D c in col)
        {
            WeakSpot w = c.GetComponent<WeakSpot>();
            if (w != null)
            {
                if (w.IsHittable() && w.IsPlayerCorrectPos(transform))
                    weakSpotsReached[i] = w.gameObject.transform.parent.parent.gameObject;
            }
            i++;
        }

        return weakSpotsReached;
    }

    void FinalizeAttack()
    {
        GameObject[] attackedWeakSpots = CheckForWeakSpots(colliderDetector.enemiesInWeaponRange.ToArray());

        foreach(Collider2D c in colliderDetector.enemiesInWeaponRange)
        {
            HittableBehaviour hittableBehaviour = c.GetComponent<HittableBehaviour>();
            if (hittableBehaviour != null)
            {
                bool reachedWeakSpot = false;

                foreach (GameObject o in attackedWeakSpots)
                {
                    if (o == hittableBehaviour.gameObject)
                    {
                        reachedWeakSpot = true;
                        break;
                    }
                }

                ApplyEffect(hittableBehaviour, reachedWeakSpot);
            }
        }
    }

    void ApplyEffect(HittableBehaviour hittableBehaviour, bool hitWeakSpot)
    {
        if (hittableBehaviour.IsBounceable() && playerController.ShouldBounce())
        {
            playerController.Bounce();
        }

        hittableBehaviour.TakeDamage(damage, hitWeakSpot);
    }

    public void StartAttackUp() { attackUpCollider.enabled = true; }
    public void EndAttackUp() { attackUpCollider.enabled = false; colliderDetector.enemiesInWeaponRange = new List<Collider2D>(); }

    public void StartAttackHorizontal() { attackHorizontalCollider.enabled = true; }
    public void EndAttackHorizontal() { attackHorizontalCollider.enabled = false; colliderDetector.enemiesInWeaponRange = new List<Collider2D>(); }

    public void StartAttackDown() { attackDownCollider.enabled = true; }
    public void EndAttackDown() { attackDownCollider.enabled = false; colliderDetector.enemiesInWeaponRange = new List<Collider2D>(); }
}
