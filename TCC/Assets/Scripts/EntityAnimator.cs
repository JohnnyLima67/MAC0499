using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EntityAnimator : MonoBehaviour
{
    public virtual IEnumerator PlayTakeDamage()
    {
        yield break;
    }

    public virtual IEnumerator PlayDie()
    {
        yield break;
    }
}
