using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;

public class Stomp : ActionBase
{
	GameObject spikePrefab;
	GameObject spikeUndergroundReference;
	Transform playerTransform;

	GameObject currentSpike;

	public Stomp(GameObject spikePrefab, GameObject spikeUndergroundReference)
	{
		this.spikePrefab = spikePrefab;
		this.spikeUndergroundReference = spikeUndergroundReference;
	}

    protected override void OnStart()
    {
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
	}

	protected override TaskStatus OnUpdate()
	{
		Vector3 spikePosition = new Vector3(playerTransform.position.x,
											spikeUndergroundReference.transform.position.y,
											playerTransform.position.z);

		currentSpike = GameObject.Instantiate(spikePrefab, spikePosition, Quaternion.identity);

		return TaskStatus.Success;
	}
}
