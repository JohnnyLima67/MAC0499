using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyAnimator : EntityAnimator
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

    public override IEnumerator PlayTakeCriticalDamage()
    {
        isInCriticalAnimation = true;
        float interval = healthbarManager.GetDamageInterval();
        playerSprite.DOColor(Color.magenta, interval / 2);
        gameObject.transform.DOShakePosition(0.8f, 2.0f, 15, 90.0f, false, true);

        yield return new WaitForSeconds(interval / 2);

        playerSprite.DOColor(Color.white, interval / 2);

        isInCriticalAnimation = false;
        yield break;
    }

    public override IEnumerator PlayDie()
    {
        unityAnimator.SetTrigger("Dead");

        yield return new WaitForSeconds(unityAnimator.GetCurrentAnimatorStateInfo(0).length + 10);
        Destroy(gameObject);
        yield break;
        
    }

    public bool IsInCriticalAnimation()
    {
        return isInCriticalAnimation;
    }
}
