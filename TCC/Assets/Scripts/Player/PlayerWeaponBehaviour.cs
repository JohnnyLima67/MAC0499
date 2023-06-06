using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponBehaviour : MonoBehaviour
{
    [SerializeField] TarodevController.PlayerController playerController;
    [SerializeField] float damage;
    [SerializeField] Animator animator;
    [SerializeField] Transform pointArea1Horizontal;
    [SerializeField] Transform pointArea2Horizontal;

    [SerializeField] Transform pointArea1Down;
    [SerializeField] Transform pointArea2Down;

    [SerializeField] Transform pointArea1Up;
    [SerializeField] Transform pointArea2Up;

    void Awake()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<TarodevController.PlayerController>();
    }

    public void TriggerHorizontalAttackAnimation()
    {
        animator.SetTrigger("AttackHorizontal");
    }

    public void TriggerDownAttackAnimation()
    {
        animator.SetTrigger("AttackDown");
    }

    public void TriggerUpAttackAnimation()
    {
        animator.SetTrigger("AttackUp");
    }

    public Collider2D[] OverlapAttackHorizontal(LayerMask targetLayer)
    {
        return Physics2D.OverlapAreaAll(new Vector2(pointArea1Horizontal.position.x, pointArea1Horizontal.position.y),
                                        new Vector2(pointArea2Horizontal.position.x, pointArea2Horizontal.position.y),
                                        targetLayer);
    }

    public Collider2D[] OverlapAttackDown(LayerMask targetLayer)
    {
        return Physics2D.OverlapAreaAll(new Vector2(pointArea1Down.position.x, pointArea1Down.position.y),
                                        new Vector2(pointArea2Down.position.x, pointArea2Down.position.y),
                                        targetLayer);
    }

    public Collider2D[] OverlapAttackUp(LayerMask targetLayer)
    {
        return Physics2D.OverlapAreaAll(new Vector2(pointArea1Up.position.x, pointArea1Up.position.y),
                                        new Vector2(pointArea2Up.position.x, pointArea2Up.position.y),
                                        targetLayer);
    }

    public void ApplyEffect(HittableBehaviour hittableBehaviour)
    {
        hittableBehaviour.TakeDamage(damage);
        if (hittableBehaviour.IsBounceable() && playerController.ShouldBounce())
        {
            playerController.Bounce();
        }
    }

     void OnDrawGizmos()
     {
         if(pointArea1Horizontal != null && pointArea2Horizontal != null)
         {
             // Draws a blue line from this transform to the target
             Gizmos.color = Color.red;
             Gizmos.DrawLine(pointArea1Horizontal.position, pointArea2Horizontal.position);
         }
         if(pointArea1Down != null && pointArea2Down != null)
         {
             // Draws a blue line from this transform to the target
             Gizmos.color = Color.red;
             Gizmos.DrawLine(pointArea1Down.position, pointArea2Down.position);
         }
         if(pointArea1Up != null && pointArea2Up != null)
         {
             // Draws a blue line from this transform to the target
             Gizmos.color = Color.red;
             Gizmos.DrawLine(pointArea1Up.position, pointArea2Up.position);
         }
     }
}
