using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
    public GameObject playerObject;

	private Transform playerCheckpoint;

    // Start is called before the first frame update
    void Awake()
	{
		// If there is an instance, and it's not me, delete myself.

		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}
		else
		{
			Instance = this;
		}

        playerObject = GameObject.FindGameObjectWithTag("Player");
	}

	public void ChangeCheckpointPosition(Transform newPosition)
	{
		playerCheckpoint = newPosition;
	}
}
