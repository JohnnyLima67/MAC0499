using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [HideInInspector] protected Rigidbody2D _rb; // Hide is for serialization to avoid errors in gizmo calls

    public virtual void BeforeStartKnockback()
    {

    }

    public virtual void AfterEndKnockback()
    {

    }

    public virtual void ApplyForce(Vector2 force)
    {
        _rb.AddForce(force, ForceMode2D.Impulse);
    }
}
