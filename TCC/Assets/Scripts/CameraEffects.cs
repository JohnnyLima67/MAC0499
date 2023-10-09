using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraEffects : MonoBehaviour
{
	[SerializeField] CinemachineImpulseSource cinemachineImpulseSource;
	[SerializeField] float shakeDuration = 0.5f;
	[SerializeField] float shakeStrength = 3.0f;
	[SerializeField] Camera mainCamera;

	public void ShakeCamera()
	{
		Debug.Log("CHAMEI SHAKE CAMERA");
		cinemachineImpulseSource.GenerateImpulseWithForce(shakeStrength);
	}
}
