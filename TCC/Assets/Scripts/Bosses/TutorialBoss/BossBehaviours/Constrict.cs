using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CleverCrow.Fluid.BTs.Tasks;
using CleverCrow.Fluid.BTs.Tasks.Actions;
using CleverCrow.Fluid.BTs.Trees;

public class Constrict : ActionBase
{
	Transform playerTransform;
	Transform groundLevelReference;
	[SerializeField] GameObject constrictPrefab;

	GameObject currentConstrict;

	public Constrict(GameObject constrictPrefab, Transform groundLevelReference)
	{
		this.constrictPrefab = constrictPrefab;
		this.groundLevelReference = groundLevelReference;
	}

    protected override void OnStart()
    {
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		groundLevelReference = GameObject.FindGameObjectWithTag("BossGroundLevelReference").transform;
	}

	protected override TaskStatus OnUpdate()
	{
		Vector3 constrictPosition = new Vector3(playerTransform.position.x,
											groundLevelReference.transform.position.y,
											playerTransform.position.z);

		currentConstrict = GameObject.Instantiate(constrictPrefab, constrictPosition, Quaternion.identity);

		return TaskStatus.Success;
	}
}
