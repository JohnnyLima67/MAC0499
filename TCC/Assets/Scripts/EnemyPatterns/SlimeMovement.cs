using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : AbstractMovement
{
    [SerializeField] EnemyCharacterController thisEnemyCharacterController;
    [SerializeField] Enemy thisEnemy;
    [SerializeField] Transform visionObject;
    [SerializeField] LayerMask groundMask;

    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float visionDistance = 10.0f;

    protected override void Move()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,
                                             Vector3.Normalize(visionObject.transform.position - transform.position),
                                             visionDistance,
                                             groundMask);

        if (hit.collider != null)
        {
            thisEnemy.Flip();
        }

        Vector3 s = Vector3.Normalize(visionObject.transform.position - transform.position) * speed;
        thisEnemyCharacterController.SetHorizontalSpeed(s);
    }
}
