using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;

public class WalkForward : ActionBase {
    float maxDistance = 10.0f;
    float speed = 5.0f;

    Rigidbody2D rb;
    Vector3 direction = new Vector3(-1, 0, 0);
    Vector3 startingPosition;

    public WalkForward(float d)
    {
        maxDistance = d;
    }

    protected override void OnStart()
    {
        rb = Owner.GetComponent<Rigidbody2D>();
        startingPosition = new Vector3(Owner.transform.position.x,
                                       Owner.transform.position.y,
                                       Owner.transform.position.z);
    }

    protected override TaskStatus OnUpdate () {
        Vector3 result = direction * speed;
        rb.velocity = result;

        float currentDistance = Vector3.Magnitude(Owner.transform.position - startingPosition);
        Debug.Log(currentDistance);
        if (currentDistance > maxDistance) return TaskStatus.Success;
        else return TaskStatus.Continue;
    }
}
