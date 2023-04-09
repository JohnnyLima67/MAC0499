using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	public Transform thisCheckpointPosition;

	private bool activated = false;

	[SerializeField] private Animator thisAnimator;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Player") && !activated)
		{
			activated = true;
			PlayActivateAnimation();
			SetNewCheckpoint();
		}
	}

	void PlayActivateAnimation()
	{
		thisAnimator.SetTrigger("Activate");
	}

	void SetNewCheckpoint()
	{
		GameManager.Instance.ChangeCheckpointPosition(thisCheckpointPosition);
	}
}
