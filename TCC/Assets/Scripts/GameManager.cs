using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
	[SerializeField] private GameObject startPosObj;
    public static GameManager Instance { get; private set; }
    public GameObject playerObject;
	public SettingsData settingsData = new SettingsData();

	private bool isInstance = false;
    private Vector3 playerCheckpoint;
	private Vector3 _startPosLvl;
	const string settingsSaveDataPath = "/SettingsSaveData.dat";

    // Start is called before the first frame update
    void Awake()
    {
		HandlePersistentSettingsData();

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

	private void init()
	{
		HandlePlayerCheckpoint();
	}

	public void SaveSettingsData()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream saveFile = new FileStream(Application.persistentDataPath + settingsSaveDataPath, FileMode.Create);
		bf.Serialize(saveFile, settingsData);
		saveFile.Close();
	}

	void HandlePersistentSettingsData()
	{
		if (File.Exists(Application.persistentDataPath + settingsSaveDataPath))
		{
			Debug.Log("Entrei no init no GameManager");
			BinaryFormatter bf = new BinaryFormatter();
			FileStream settingsSaveFile = File.Open(Application.persistentDataPath + settingsSaveDataPath, FileMode.Open);
			settingsData = (SettingsData) bf.Deserialize(settingsSaveFile);
			settingsSaveFile.Close();
		}
		else
		{
			SaveSettingsData();
		}
	}

	void HandlePlayerCheckpoint()
	{
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
