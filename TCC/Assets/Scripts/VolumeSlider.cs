using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer objAudioMixer;
    [SerializeField] private string audioMixerParameter;

	private Slider slider;

	void Awake()
	{
		slider = gameObject.GetComponent<Slider>();
		if(!slider)
		{
			Debug.LogError("Error, this object does not have a Slider component!");
		}
	}

    public void ChangeVolume(float sliderValue)
    {
		if (audioMixerParameter == "SFX")
		{
			GameManager.Instance.settingsData.SFXVolume = sliderValue;
		}
		else if (audioMixerParameter == "music")
		{
			GameManager.Instance.settingsData.musicVolume = sliderValue;
		}
		else // Master volume
		{
			GameManager.Instance.settingsData.masterVolume = sliderValue;
		}

        objAudioMixer.SetFloat(audioMixerParameter, Mathf.Log10(sliderValue) * 20);
    }
}
