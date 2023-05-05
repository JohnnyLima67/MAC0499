using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController controller;

	public float runSpeed = 40f;

    [SerializeField] PlayerAnimator animator;
    [SerializeField] PlayerAttackBehaviour attackBehaviour;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
		}
		else if (Input.GetButtonUp("Jump"))
		{
			jump = false;
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

        if (Input.GetButtonDown("Fire1"))
        {
            attackBehaviour.InitAttack();
        }
	}

	void FixedUpdate ()
	{
        if (!animator.IsInCriticalAnimation())
        {
            // Move our character
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        }
	}
}
