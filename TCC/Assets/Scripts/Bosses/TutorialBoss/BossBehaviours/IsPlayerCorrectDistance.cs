using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;
using FSM;

public class IsPlayerCorrectDistance: ConditionBase
{
	[SerializeField] float triggerDistance = 10.0f;
	Transform player;

    protected override void OnInit()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	protected override bool OnUpdate()
    {
		if ((player.position - Owner.transform.position).magnitude < triggerDistance)
			return true;

		return false;
	}
}
