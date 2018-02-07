using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour{

	//movement
	float speed;

	//components
	Rigidbody playerRigidbody; //character's Rigidbody
	Stats playerStats; //character's stats



	void SpeedChange(){
		if(Input.GetButton("Acceleration")){
			speed = playerStats.runningSpeed;
		}else{
			speed = playerStats.walkingSpeed;
		}
	}

	void Move(){
		//press button
		float horizontalDirection = Input.GetAxis("Horizontal");

		//jump
		if((playerStats.isGrounded) && (Input.GetButton("Jump"))){
			playerRigidbody.AddForce(new Vector3 (-horizontalDirection*0.5f, playerStats.jump, 0), ForceMode.Impulse);
		}

		//move
		if(playerStats.isGrounded){
			//if player pressed Shift, then speed will be change
			SpeedChange();

			playerRigidbody.velocity = new Vector3(horizontalDirection * speed, playerRigidbody.velocity.y, 0);
		}
	}



	//use this for initialization
	void Awake(){
		playerRigidbody = GetComponent<Rigidbody>();
		playerStats = GetComponent<Stats>();
	}

	//update is fixed called once per delta
	void FixedUpdate(){
		Move();


	}

}
