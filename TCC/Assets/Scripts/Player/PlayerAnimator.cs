using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAnimator : EntityAnimator
{
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] HealthManager healthbarManager;

    private bool isInCriticalAnimation = false;

    public override IEnumerator PlayTakeDamage()
    {
        isInCriticalAnimation = true;
        float interval = healthbarManager.GetDamageInterval();
        playerSprite.DOColor(Color.red, interval / 2);

        yield return new WaitForSeconds(interval / 2);

        playerSprite.DOColor(Color.white, interval / 2);

        isInCriticalAnimation = false;
        yield break;
    }

    public override IEnumerator PlayDie()
    {
        isInCriticalAnimation = true;
        gameObject.transform.DOShakePosition(1.0f, 0.5f, 10, 90.0f, false, true);

        yield return new WaitForSeconds(1.0f);

        Vector3 newEndPosition = new Vector3(gameObject.transform.position.x, -1000.0f, 0.0f);
        gameObject.transform.DOMove(newEndPosition, 100.0f);

        yield return new WaitForSeconds(4.0f);

        isInCriticalAnimation = false;

        yield break;
    }

    public IEnumerator PlayPlayerAttackAnimation(PlayerWeaponBehaviour playerWeapon)
    {
        unityAnimator.SetTrigger("Attack");
        playerWeapon.TriggerAttackAnimation();

        yield break;
    }

    public bool IsInCriticalAnimation()
    {
        return isInCriticalAnimation;
    }
}
