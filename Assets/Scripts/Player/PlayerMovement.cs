using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

	//movement variables
	float speed; //character's speed
	public float walkingSpeed; //character's walking speed
	public float runningSpeed; //character's running speed
    public float jump; //character's jump height

	//component variables
	Rigidbody playerRigidbody; //character's Rigidbody component
	PlayerStats playerStats; //character's stats



	void SpeedChange(){
		if(Input.GetAxis("Acceleration") > 0){
			speed = runningSpeed;
		}else if(Input.GetAxis("Acceleration") == 0){
			speed = walkingSpeed;
		}
	}

	void Move(){
		//press button
		float verticalDirection = Input.GetAxis("Jump");
		float horizontalDirection = Input.GetAxis("Horizontal");

		//jump
		if(playerStats.isGrounded && (verticalDirection > 0)){
            
            playerRigidbody.AddForce(new Vector3 (0, jump*Time.deltaTime, 0), ForceMode.Impulse);
            //Input.ResetInputAxes();
        }

		//move
		if(playerStats.isGrounded){
			//if player pressed Shift, then speed will be change
			SpeedChange();

			playerRigidbody.velocity = new Vector3(horizontalDirection * speed, playerRigidbody.velocity.y, 0);
		}
        
    }



	//use this for initialization
	void Start(){
		playerRigidbody = GetComponent<Rigidbody>();
		playerStats = GetComponent<PlayerStats>();
	}

	//update is fixed called once per delta
	void FixedUpdate(){
		Move();
        
    }

}
