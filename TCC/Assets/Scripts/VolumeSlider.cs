using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer objAudioMixer;
    [SerializeField] private string audioMixerParameter;

    public void ChangeVolume(float sliderValue)
    {
        Debug.Log(Mathf.Log10(sliderValue) * 20);
        objAudioMixer.SetFloat(audioMixerParameter, Mathf.Log10(sliderValue) * 20);
    }
}
