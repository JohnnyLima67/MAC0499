using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponBehaviour : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] Animator animator;
    [SerializeField] Transform pointArea1;
    [SerializeField] Transform pointArea2;

    public void TriggerAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    public Collider2D[] OverlapAttack(LayerMask targetLayer)
    {
        return Physics2D.OverlapAreaAll(new Vector2(pointArea1.position.x, pointArea1.position.y),
                                        new Vector2(pointArea2.position.x, pointArea2.position.y),
                                        targetLayer);
    }

    public void ApplyEffect(HittableBehaviour hittableBehaviour)
    {
        hittableBehaviour.TakeDamage(damage);
    }

     void OnDrawGizmos()
     {
         if(pointArea1 != null && pointArea2 != null)
         {
             // Draws a blue line from this transform to the target
             Gizmos.color = Color.red;
             Gizmos.DrawLine(pointArea1.position, pointArea2.position);
         }
     }
}
