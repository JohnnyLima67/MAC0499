using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData {
	public float SFXVolume = 1.0f;
	public float musicVolume = 1.0f;
	public float masterVolume = 1.0f;
}

public class PersistentSettingsData : MonoBehaviour
{
	SettingsData settingsData = new SettingsData();

	PersistentSettingsData(SettingsData settingsData)
	{
		this.settingsData = settingsData;
	}
}
