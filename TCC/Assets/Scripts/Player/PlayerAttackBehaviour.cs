using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {HORIZONTAL, UP, DOWN}

public class PlayerAttackBehaviour : MonoBehaviour
{
    [SerializeField] TarodevController.PlayerController playerCharacterController;
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

    public void InitProjectile()
    {
        StartCoroutine(playerAnimator.PlayPlayerProjectileAnimation(playerRangedWeapon));
    }

    public void LaunchProjectile()
    {
        playerRangedWeapon.Fire();
    }

    public void StopPlayerMovement()
    {
        playerCharacterController.TakeAwayInputControl();
    }

    public void ReturnPlayerMovement()
    {
        playerCharacterController.ReturnInputControl();
    }

    public void ResetPlayerSpeed()
    {
        playerCharacterController.ResetPlayerSpeed();
    }
}
