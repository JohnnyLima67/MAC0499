using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackBehaviour : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    private float knockBackDuration = 1.0f;
    private float currentTime = 0.0f;
    private bool isInKnockback = false;

    public virtual void ApplyKnockback(Vector2 force, float duration)
    {
        characterController.BeforeStartKnockback();
        characterController.ApplyForce(force);
        knockBackDuration = duration;
        isInKnockback = true;
    }

    public virtual void EndKnockback()
    {
        characterController.AfterEndKnockback();
        isInKnockback = false;
    }

    void Update()
    {
        if (!isInKnockback) return;

        currentTime += Time.deltaTime;

        if (currentTime >= knockBackDuration){
            EndKnockback();
            currentTime = 0.0f;
        }
    }
}
