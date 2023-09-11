using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameObject startPosObj;
	private Vector3 _startPosLvl;
    public static GameManager Instance { get; private set; }
    public GameObject playerObject;
	private bool isInstance = false;
    private Vector3 playerCheckpoint;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            // There's already an instance, destroy this one
			Debug.Log("Deletei");
			init();
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
			isInstance = true;
			_startPosLvl = startPosObj.transform.position;
            DontDestroyOnLoad(gameObject.transform.root.gameObject);
        }

    }

	private void init(){

		// Find the player object only if it's not assigned in the Inspector
		if (Instance.playerObject == null && Instance.isInstance == true)
		{
			Instance.playerObject = GameObject.FindGameObjectWithTag("Player");
		}

		// Initialize the player's position if a checkpoint is available
		if (Instance.playerCheckpoint != new Vector3(0,0,0) && Instance.isInstance == true)
		{
			Debug.Log(Instance.playerCheckpoint);
			Instance.playerObject.transform.position = Instance.playerCheckpoint;
		}
		else if(Instance.playerCheckpoint == new Vector3(0,0,0) && Instance.isInstance == true) {
			Debug.Log(Instance._startPosLvl);
			Instance.playerObject.transform.position = Instance._startPosLvl;
		}

	}
    public void ChangeCheckpointPosition(Transform newPosition)
    {
        playerCheckpoint = newPosition.position;
    }
}
