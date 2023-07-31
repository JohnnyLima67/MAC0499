using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPointMove : AbstractMovement
{
    [SerializeField] Vector3[] points;
    [SerializeField] Enemy thisEnemy;

    int target = 1;
    int speed = 5;

    Vector3 startPosition;
    bool startPositionSet = false;

    protected override void Move()
    {
        if (points.Length < 2)
            return;

        if (!startPositionSet)
        {
            startPosition = transform.position;
            startPositionSet = true;
        }
            

        Vector3 globalTarget = startPosition + points[target];

        Vector3 movement = globalTarget - transform.position;

        float frameOffset = speed * Time.deltaTime;
        float distToTarget = movement.sqrMagnitude;

        if (distToTarget > frameOffset)
        {

            transform.position += movement.normalized * speed * Time.deltaTime;
        }
        else
        {
            transform.position = globalTarget;
            target = 1 - target;
            thisEnemy.Flip();
        }
    }
}
