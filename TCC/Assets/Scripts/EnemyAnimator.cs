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

    float alphaVal = playerSprite.color.a;

    while (alphaVal > 0)
    {
        alphaVal -= 0.01f * Time.deltaTime * 15; // Adjust the rate of fading with Time.deltaTime
        alphaVal = Mathf.Clamp01(alphaVal); // Ensure the alpha value stays within [0, 1]
        Color tmp = playerSprite.color;
        tmp.a = alphaVal;
        playerSprite.color = tmp;
        yield return null; // Wait for the next frame
    }

    // Optional: Set a specific alpha value at the end of the fade
    // playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0);
    
    Destroy(gameObject);
    yield break;
}


    public bool IsInCriticalAnimation()
    {
        return isInCriticalAnimation;
    }
}
