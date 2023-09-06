using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
	public void AfterAnimationEnd()
	{
		Debug.Log("Deleta Spike...");
		Destroy(gameObject.transform.parent.gameObject);
	}
}
