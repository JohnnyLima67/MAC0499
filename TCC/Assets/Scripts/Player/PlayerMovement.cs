using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController controller;

	public float runSpeed = 40f;

    [SerializeField] PlayerAnimator animator;
    [SerializeField] PlayerAttackBehaviour attackBehaviour;

	float horizontalMove = 0f;
    float verticalMove = 0f;
	bool jump = false;
	bool crouch = false;
    Direction attackDirection = Direction.HORIZONTAL;

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical");

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

        // if (Input.GetButtonDown("Fire1"))
        // {
        //     attackBehaviour.InitAttack(attackDirection);
        // }
        if (Input.GetButtonDown("Fire2"))
        {
            attackBehaviour.InitProjectile();
        }
	}

	void FixedUpdate ()
	{
        if (!animator.IsInCriticalAnimation())
        {
            // Move our character
            attackDirection = controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove, crouch, jump);
        }
	}
}
