using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrictTrap : MonoBehaviour
{
	[SerializeField] float setupTime;
	[SerializeField] float constrictTime;

	float currentTime = 0.0f;
	bool hasActivated = false;
	TarodevController.PlayerController thisPlayerController = null;

	void Update()
	{
		currentTime += Time.deltaTime;

		if (currentTime < setupTime) return;

		if (thisPlayerController != null)
		{
			thisPlayerController.TakeAwayInputControl();
			thisPlayerController.ResetPlayerSpeed();

			if (!hasActivated)
				currentTime = setupTime;

			hasActivated = true;
		}

		if (currentTime - setupTime > constrictTime)
		{
			if (thisPlayerController != null)
				thisPlayerController.ReturnInputControl();

			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!col.CompareTag("Player")) return;

		thisPlayerController = col.gameObject.GetComponent<TarodevController.PlayerController>();
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (!col.CompareTag("Player")) return;

		thisPlayerController = null;
	}
}
