using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPointMove : AbstractMovement
{
    [SerializeField] Transform[] points;
    int target = 1;
    int speed = 5;

    protected override void Move()
    {
        if (points.Length < 2)
            return;

        Vector3 movement = points[target].position - transform.position;

        float frameOffset = speed * Time.deltaTime;
        float distToTarget = movement.sqrMagnitude;

        if (distToTarget > frameOffset)
        {

            transform.position += movement.normalized * speed * Time.deltaTime;
        }
        else
        {
            transform.position = points[target].position;
            target = 1 - target;
        }
    }
}
