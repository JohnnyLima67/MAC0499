using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {HORIZONTAL, UP, DOWN}

public class PlayerAttackBehaviour : MonoBehaviour
{
    [SerializeField] PlayerWeaponBehaviour playerWeapon;
    [SerializeField] PlayerRangedWeaponBehaviour playerRangedWeapon;
    [SerializeField] PlayerAnimator playerAnimator;
    [SerializeField] LayerMask enemyLayer;

    TarodevController.PlayerController playerController;

    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<TarodevController.PlayerController>();
        playerController.Attacked += InitAttack;
        playerController.RangedAttacked += InitProjectile;
    }

    public void InitAttack()
    {
        Direction dir = playerController.GetDirection();
        if (dir == Direction.HORIZONTAL || dir == Direction.HORIZONTAL)
            StartCoroutine(playerAnimator.PlayPlayerHorizontalAttackAnimation(playerWeapon));
        else if (dir == Direction.DOWN)
            StartCoroutine(playerAnimator.PlayPlayerDownAttackAnimation(playerWeapon));
        else if(dir == Direction.UP)
            StartCoroutine(playerAnimator.PlayPlayerUpAttackAnimation(playerWeapon));
        else
        {
            Debug.LogError("Direction not recognized for InitAttack");
            return;
        }
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

    void FinalizeAttack(Collider2D[] col)
    {
        GameObject[] attackedWeakSpots = CheckForWeakSpots(col);

        foreach(Collider2D c in col)
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

                playerWeapon.ApplyEffect(hittableBehaviour, reachedWeakSpot);
            }
        }
    }

    public void AttackHorizontal()
    {
        Collider2D[] col = playerWeapon.OverlapAttackHorizontal(enemyLayer);
        FinalizeAttack(col);
    }

    public void AttackDown()
    {
        Collider2D[] col = playerWeapon.OverlapAttackDown(enemyLayer);
        FinalizeAttack(col);
    }

    public void AttackUp()
    {
        Collider2D[] col = playerWeapon.OverlapAttackUp(enemyLayer);
        FinalizeAttack(col);
    }

    public void InitProjectile()
    {
        StartCoroutine(playerAnimator.PlayPlayerProjectileAnimation(playerRangedWeapon));
    }

    public void LaunchProjectile()
    {
        playerRangedWeapon.Fire();
    }
}
