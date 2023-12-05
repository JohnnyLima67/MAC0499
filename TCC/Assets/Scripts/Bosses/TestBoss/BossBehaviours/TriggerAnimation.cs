using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;

public class TriggerAnimation : ActionBase
{
    [SerializeField] string triggerName;

    public TriggerAnimation(string triggerName)
    {
        this.triggerName = triggerName;
    }

    protected override void OnStart()
    {
        Animator thisEnemyAnimator = Owner.GetComponent<Animator>();
        thisEnemyAnimator.SetTrigger(this.triggerName);
    }

    protected override TaskStatus OnUpdate () {
        return TaskStatus.Success;
    }
}
