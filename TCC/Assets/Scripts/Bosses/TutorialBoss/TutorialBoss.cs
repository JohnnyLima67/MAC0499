using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;
using FSM;

public class TutorialBoss : MonoBehaviour
{
	[SerializeField] BehaviorTree mainBehaviour;
	[SerializeField] GameObject spikePrefab;
	[SerializeField] GameObject spikeUndergroundReferece;

    // Start is called before the first frame update
    void Start()
    {
		mainBehaviour = new BehaviorTreeBuilder(gameObject)
			.Sequence()
			  .WaitTime(0.5f)
			  .SelectorRandom()
			    .Sequence()
			      .Condition(() => {return IsPlayerInCorrectDistance();})
			      .TriggerAnimation("Sweep")
			    .End()
			    .Sequence()
			      .TriggerAnimation("Stomp")
			      .WaitTime(0.35f)
			      .Stomp(spikePrefab, spikeUndergroundReferece)
			    .End()
			  .End()
			.End().Build();
    }

    // Update is called once per frame
    void Update()
    {
        mainBehaviour.Tick();
    }

	bool IsPlayerInCorrectDistance()
	{
		return true;
	}
}
