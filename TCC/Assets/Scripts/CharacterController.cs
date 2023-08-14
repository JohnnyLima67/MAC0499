using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rb; // Hide is for serialization to avoid errors in gizmo calls
    [SerializeField] float thisDrag;

    protected Vector2 thisSpeed;
    protected Vector2 thisExternalSpeed;

    public virtual void BeforeStartKnockback()
    {
        this.SetSpeed(Vector2.zero);
    }

    public virtual void AfterEndKnockback()
    {

    }

    public virtual void ApplyForce(Vector2 force)
    {
        this.ApplySpeed(force);
    }

    public virtual void ApplySpeed(Vector2 speed)
    {
        thisExternalSpeed += speed;
    }

    public virtual void EndExternalSpeed()
    {
        thisExternalSpeed = Vector2.zero;
    }

    public virtual void SetSpeed(Vector2 speed)
    {
        thisSpeed = speed;
    }

    public virtual void SetHorizontalSpeed(Vector2 speed)
    {
        thisSpeed.x = speed.x;
    }

    public virtual void SetVerticalSpeed(Vector2 speed)
    {
        thisSpeed.y = speed.y;
    }

    public virtual void FixedUpdate()
    {
        _rb.velocity = thisSpeed + thisExternalSpeed;
        thisExternalSpeed = Vector2.MoveTowards(thisExternalSpeed, Vector2.zero, thisDrag * Time.fixedDeltaTime);
    }
}
