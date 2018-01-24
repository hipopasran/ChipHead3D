using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour {

	//character's variable
	public float climbingSpeed; //character's climbing speed
	public float fastClimbingSpeed; //character's fast climbing speed
	public float jumpingOff; //character's jump power
	float speed;

	//component variables
	Rigidbody playerRigidbody; //character's Rigidbody component
	PlayerStats playerStats; //character's stats



	void SpeedChange(){
		if(Input.GetAxis("Acceleration") > 0){
			speed = fastClimbingSpeed;
		}else if(Input.GetAxis("Acceleration") == 0){
			speed = climbingSpeed;
		}
	}

	void Move(){
		float verticalDirection = Input.GetAxis("Vertical");
		float horizontalDirection = Input.GetAxis("Horizontal");

		//if player pressed Shift, then speed will be change
		SpeedChange();

		playerRigidbody.velocity = new Vector3 (0, verticalDirection * speed, 0);

		if(playerStats.isGrounded){
			playerRigidbody.velocity = new Vector3(horizontalDirection * speed, playerRigidbody.velocity.y, 0);
		}

		if((!playerStats.isGrounded) && (horizontalDirection != 0) && (verticalDirection > 0)){
			playerRigidbody.AddForce(new Vector3(horizontalDirection * jumpingOff, 0, 0), ForceMode.Impulse);
		}
	}



	//use this for initialization
	void Start(){
		playerRigidbody = GetComponent<Rigidbody>();
		playerStats = GetComponent<PlayerStats>();
	}
	
	//update is called once per delta
	void FixedUpdate(){
		Move();
	}
}
