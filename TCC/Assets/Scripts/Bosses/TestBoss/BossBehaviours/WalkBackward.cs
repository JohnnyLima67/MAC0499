using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;

public class WalkBackward : ActionBase {
    float speed = 5.0f;
    [SerializeField] float maxDistance = 10.0f;

    EnemyCharacterController thisCharacterController;
    Vector3 direction = new Vector3(1, 0, 0);

    float currentTime = 0.0f;
    float maxTime;

    public WalkBackward(float d, float speed)
    {
        maxDistance = d;
        this.speed = speed;
        maxTime = d / speed;
    }

    protected override void OnStart()
    {
        thisCharacterController = Owner.GetComponent<EnemyCharacterController>();
        currentTime = 0.0f;
    }

    protected override TaskStatus OnUpdate () {
        Vector3 result = direction * speed;
        thisCharacterController.SetSpeed(result);
        currentTime += Time.deltaTime;

        if (currentTime > maxTime) return TaskStatus.Success;
        else return TaskStatus.Continue;
    }

    protected override void OnExit()
    {
        thisCharacterController.SetSpeed(Vector2.zero);
    }
}
