using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBossAnimationEvents : MonoBehaviour
{
	[SerializeField] BoxCollider2D sweepCollider;

	public void ActivateSweepAttack() { sweepCollider.enabled = true; }
	public void DeactivateSweepAttack() { sweepCollider.enabled = false; }
}
