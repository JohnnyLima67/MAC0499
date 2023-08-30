using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : AbstractMovement
{
    [SerializeField] EnemyCharacterController thisEnemyCharacterController;
    [SerializeField] Enemy thisEnemy;
    [SerializeField] Transform visionObject;
    [SerializeField] Transform bottomObject;

    [SerializeField] LayerMask groundMask;
    //[SerializeField] HealthManager healthManager;

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float visionDistance = 10.0f;

    protected override void Move()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position,
                                             Vector3.Normalize(visionObject.transform.position - bottomObject.position),
                                             visionDistance,
                                             groundMask);

        if (hit.collider != null)
        {
            thisEnemy.Flip();
        }

        Vector3 s = Vector3.Normalize(visionObject.transform.position - bottomObject.position) * speed;
        thisEnemyCharacterController.SetHorizontalSpeed(s);
    }

    protected override void NotMove()
    {
        thisEnemyCharacterController.SetSpeed(Vector2.zero);
        thisEnemyCharacterController.EndExternalSpeed();
        return;
    }


}
