using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	//stats variables
	public bool isGrounded; //if character is grounded, then true
	public bool onLadder; //if character on a ladder, then true

	//ground check variables
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


	
	//update is called once per frame
	void FixedUpdate(){
		IsGrounded();
		OnLadder();
	}

}
