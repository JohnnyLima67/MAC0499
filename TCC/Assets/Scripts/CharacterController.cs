using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D _rb; // Hide is for serialization to avoid errors in gizmo calls
    [SerializeField] float thisDrag;
    [SerializeField] float maxFallingSpeed = 20.0f;
    [SerializeField] float gravity = 9.8f;
    [SerializeField] float groundRadius = 0.2f;
    [SerializeField] Transform bottomOfFeet;
    [SerializeField] LayerMask groundLayer;

    protected Vector2 thisSpeed;
    protected Vector2 thisExternalSpeed;
    protected Vector2 currentFallingSpeed;
    protected bool isGrounded = false;

    void Awake()
    {
        currentFallingSpeed = Vector2.zero;
    }

    void Update()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(bottomOfFeet.position, groundRadius, groundLayer);

        if (col.Length > 0 && !isGrounded)
        {
            isGrounded = true;
        }
        else if (isGrounded) isGrounded = false;
    }

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
        if (!isGrounded)
        {
            currentFallingSpeed = Vector2.MoveTowards(currentFallingSpeed, new Vector2(0, -maxFallingSpeed),
                                                      gravity * Time.fixedDeltaTime);
            _rb.velocity = thisSpeed + thisExternalSpeed + currentFallingSpeed;
        }
        else
        {
            _rb.velocity = thisSpeed + thisExternalSpeed;
            currentFallingSpeed = Vector2.zero;
        }

        thisExternalSpeed = Vector2.MoveTowards(thisExternalSpeed, Vector2.zero, thisDrag * Time.fixedDeltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(bottomOfFeet.position, groundRadius);
    }
}
