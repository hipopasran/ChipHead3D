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
    public bool swinging; //if on rope, then true

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

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Rope")
        {
            Input.ResetInputAxes();
            swinging = true;

            HingeJoint hinge = gameObject.AddComponent<HingeJoint>() as HingeJoint;
            hinge.connectedBody = other.gameObject.GetComponent<Rigidbody>();
        }
    }

	void Update()
    {
        
    }
	//update is called once per frame
	void FixedUpdate()
    {

        if (swinging == false)
        {
            GetComponent<RopeMovement>().enabled = false;
            GetComponent<GroundMovement>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            
        }
        else
        {
            GetComponent<RopeMovement>().enabled = true;
            GetComponent<GroundMovement>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }

        IsGrounded();
		OnLadder();
        
		IsMoving();
		IsNoisy();
	}

}
