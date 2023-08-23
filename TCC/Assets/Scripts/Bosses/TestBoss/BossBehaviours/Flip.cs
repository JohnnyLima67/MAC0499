using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;

public class Flip : ActionBase {
    Enemy thisEnemy;

    protected override void OnStart()
    {
        thisEnemy = Owner.GetComponent<Enemy>();
        thisEnemy.Flip();
    }

    protected override TaskStatus OnUpdate ()
    {
        return TaskStatus.Success;
    }

    protected override void OnExit()
    {
    }
}
