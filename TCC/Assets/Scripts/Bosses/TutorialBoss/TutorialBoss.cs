using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;
using FSM;

public class TutorialBoss : MonoBehaviour
{
	[SerializeField] Level_teste_1_Manager lvlChanger;
	[SerializeField] HealthManager health;
	[SerializeField] BehaviorTree mainBehaviour;
	[SerializeField] GameObject spikePrefab;
	[SerializeField] GameObject spikeUndergroundReferece;

	[SerializeField] GameObject constrictPrefab;
	[SerializeField] GameObject groundLevelReference;
	[SerializeField] BTRunner thisbtRunner;

    // Start is called before the first frame update
    void Start()
    {
		// mainBehaviour = new BehaviorTreeBuilder(gameObject)
		// 	.Sequence()
		// 	  .WaitTime(1.1f)
		// 	  .SelectorRandom()
		// 	    .Sequence()
		// 	      .Condition(() => {return IsPlayerInCorrectDistance();})
		// 	      .TriggerAnimation("Sweep")
		// 	    .End()
		// 	    .Sequence()
		// 	      .TriggerAnimation("Stomp")
		// 	      .WaitTime(0.35f)
		// 	      .Stomp(spikePrefab, spikeUndergroundReferece)
		// 	    .End()
		// 	    .Sequence()
		// 	      .TriggerAnimation("Constrict")
		// 	      .WaitTime(0.7f)
		// 	      .Constrict(constrictPrefab, groundLevelReference.transform)
		// 	    .End()
		// 	  .End()
		// 	.End().Build();
    }

    // Update is called once per frame
    void Update()
    {
		if (health.isDead())
		{
			thisbtRunner.StopTree();
			Finish();
		}
    }

	private IEnumerator Finish(){
		Debug.Log("Passou");

		yield return new WaitForSeconds(10);
		lvlChanger.FinishLevel();
		yield break;

	}

	bool IsPlayerInCorrectDistance()
	{
		return true;
	}
}
