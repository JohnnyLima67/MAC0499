using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredaplantAnimationEvents : MonoBehaviour
{
    [SerializeField] BoxCollider2D attackCollider;

    void EnableAttackCollider() { attackCollider.enabled = true; }
    void DisableAttackCollider() { attackCollider.enabled = false; }
}
