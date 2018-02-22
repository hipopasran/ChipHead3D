using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {

	//characteristics
	public float walkingSpeed; //character's walking speed
	public float runningSpeed; //character's running speed
	public float climbingSpeed; //character's climbing speed
	public float fastClimbingSpeed; //character's fast climbing speed
	public float jump; //character's jump height

	//statuses
	public bool isGrounded; //if character is grounded, then true
	public bool isMoving; //if character is walking, then true
	public bool onLadder; //if character on a ladder, then true
	public bool isNoisy; //if character is noisy, then true

	//areas
	public bool glass; //if character in the glass area, then true

	//ground check
	public LayerMask groundCheckLayer; //ground layer
	public Transform groundCheckStart; //starting capsule's point
	public Transform groundCheckFinish; //finishing capsule's point
	float groundCheckRadius = 0.12f; //capsule's radius
	Collider[] groundCollisions;



	void OnLadder(){
		onLadder = Physics.Raycast(transform.position, Vector3.right, transform.lossyScale.x/2);

		//if ladder is absent right
		if(!onLadder){
			onLadder = Physics.Raycast(transform.position, Vector3.left, transform.lossyScale.x/2);
		}
	}

	void IsGrounded(){
		groundCollisions = Physics.OverlapCapsule(groundCheckStart.position, groundCheckFinish.position, groundCheckRadius, groundCheckLayer);
		if(groundCollisions.Length > 0){
			isGrounded = true;
		}else{
			isGrounded = false;
		}
	}

	void IsMoving(){
		if(gameObject.GetComponent<Rigidbody>().velocity != Vector3.zero){
			isMoving = true;
		}else{
			isMoving = false;
		}
	}

	void IsNoisy(){
		if((Input.GetButton("Acceleration") || glass) && isMoving){
			isNoisy = true;
		}else{
			isNoisy = false;
		}
	}



	void FixedUpdate(){
		IsGrounded();
		OnLadder();
		IsMoving();
		IsNoisy();
	}

}
