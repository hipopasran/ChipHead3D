using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour {

	//movement
	float speed;

	//components
	Rigidbody playerRigidbody; //character's Rigidbody
	Stats playerStats; //character's stats



	void SpeedChange(){
		if(Input.GetButton("Acceleration")){
			speed = playerStats.fastClimbingSpeed;
		}else{
			speed = playerStats.climbingSpeed;
		}
	}

	void Move(){
		float verticalDirection = Input.GetAxis("Vertical");
		float horizontalDirection = Input.GetAxis("Horizontal");

		//if player pressed Shift, then speed will be change
		SpeedChange();

		//move
		playerRigidbody.velocity = new Vector3 (0, verticalDirection * speed, 0);

		//if player is grounded, he can move on it
		if(playerStats.isGrounded){
			playerRigidbody.velocity = new Vector3(horizontalDirection * speed, playerRigidbody.velocity.y, 0);
		}

		//jump off
		if((!playerStats.isGrounded) && (Input.GetButton("Horizontal"))){
			playerRigidbody.velocity = Vector3.zero;
			if(horizontalDirection < -0.5){
				horizontalDirection = -1;
				playerRigidbody.AddForce(new Vector3(horizontalDirection * playerStats.jump, 0, 0), ForceMode.Impulse);
			}else if(horizontalDirection > 0.5){
				horizontalDirection = 1;
				playerRigidbody.AddForce(new Vector3(horizontalDirection * playerStats.jump, 0, 0), ForceMode.Impulse);
			}
		}
	}



	//use this for initialization
	void Awake(){
		playerRigidbody = GetComponent<Rigidbody>();
		playerStats = GetComponent<Stats>();
	}
	
	//update is called once per delta
	void FixedUpdate(){
		Move();
	}
}
