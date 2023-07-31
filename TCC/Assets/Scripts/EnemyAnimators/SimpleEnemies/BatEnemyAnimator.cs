using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemyAnimator : EnemyAnimator
{
    public override IEnumerator PlayDie()
    {
        unityAnimator.SetTrigger("Death");
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
        yield break;
    }
}
