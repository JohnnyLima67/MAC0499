using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusicManager : MonoBehaviour
{
	[SerializeField] AudioSource audioSource;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!col.CompareTag("Player")) return;

		audioSource.enabled = true;
	}
}
