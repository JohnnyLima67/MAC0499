using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehaviour : MonoBehaviour
{
    [SerializeField] PlayerWeaponBehaviour playerWeapon;
    [SerializeField] PlayerAnimator playerAnimator;
    [SerializeField] LayerMask enemyLayer;

    public void InitAttack()
    {
        StartCoroutine(playerAnimator.PlayPlayerAttackAnimation(playerWeapon));
    }

    public void Attack()
    {
        Collider2D[] col = playerWeapon.OverlapAttack(enemyLayer);

        foreach(Collider2D c in col)
        {
            HittableBehaviour hittableBehaviour = c.GetComponent<HittableBehaviour>();
            playerWeapon.ApplyEffect(hittableBehaviour);
        }
    }
}
