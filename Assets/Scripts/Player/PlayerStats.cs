﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	//stats variables
	public bool isGrounded;

	//ground check variables
	public LayerMask groundCheckLayer; //ground layer
	public Transform groundCheckStart; //starting capsule's point
	public Transform groundCheckFinish; //finishing capsule's point
	float groundCheckRadius = 0.12f; //capsule's radius
	Collider[] groundCollisions;

	void IsGrounded(){
		groundCollisions = Physics.OverlapCapsule(groundCheckStart.position, groundCheckFinish.position, groundCheckRadius, groundCheckLayer);
		if(groundCollisions.Length > 0){
			isGrounded = true;
		}else{
			isGrounded = false;
		}
	}



	//use this for initialization
	void Start(){
		
	}
	
	//update is called once per frame
	void FixedUpdate(){
		IsGrounded();
	}

}
