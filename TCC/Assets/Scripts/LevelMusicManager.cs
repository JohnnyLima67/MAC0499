using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusicManager : MonoBehaviour
{
	[SerializeField] AudioSource audioSource;
	[SerializeField] float startVolume = 0.0f;
	[SerializeField] float endVolume = 0.1f;
	[SerializeField] float step = 0.01f;
	[SerializeField] float waitTimeStep = 0.001f;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!col.CompareTag("Player")) return;

		audioSource.enabled = true;
		StartCoroutine(MusicFadeIn());
	}

	IEnumerator MusicFadeIn()
	{
		for (float vol = startVolume; vol <= endVolume; vol += step)
		{
			audioSource.volume = vol;
			yield return new WaitForSeconds(waitTimeStep);
		}

		yield break;
	}
}
