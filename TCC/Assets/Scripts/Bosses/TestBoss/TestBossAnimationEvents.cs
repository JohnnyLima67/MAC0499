using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestBossAnimationEvents : MonoBehaviour
{
    [SerializeField] BoxCollider2D normalAttackCollider;
    [SerializeField] BoxCollider2D runningAttackCollider;

    void NormalAttackBegin()
    {
        normalAttackCollider.enabled = true;
    }

    void NormalAttackEnd()
    {
        normalAttackCollider.enabled = false;
    }

    void RunningAttackBegin()
    {
        runningAttackCollider.enabled = true;
    }

    void RunningAttackEnd()
    {
        runningAttackCollider.enabled = false;
    }
}
