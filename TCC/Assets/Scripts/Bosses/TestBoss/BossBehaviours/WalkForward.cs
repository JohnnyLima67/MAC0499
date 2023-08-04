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

    float currentTime = 0.0f;
    float maxTime;

    public WalkForward(float d, float speed)
    {
        maxDistance = d;
        this.speed = speed;
        maxTime = d / speed;
    }

    protected override void OnStart()
    {
        rb = Owner.GetComponent<Rigidbody2D>();
        currentTime = 0.0f;
    }

    protected override TaskStatus OnUpdate () {
        Vector3 result = direction * speed;
        rb.velocity = result;
        currentTime += Time.deltaTime;

        if (currentTime > maxTime) return TaskStatus.Success;
        else return TaskStatus.Continue;
    }

    protected override void OnExit()
    {
        rb.velocity = Vector3.zero;
    }
}
