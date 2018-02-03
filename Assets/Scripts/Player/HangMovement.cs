using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangMovement : MonoBehaviour {
<<<<<<< HEAD
		
	//while game object in the trigger colider
	void OnTriggerStay(Collider hangTrigger){
		//press button
		float verticalDirection = Input.GetAxis("Vertical");

		//check
		float xPosition = transform.position.x;
		float yPosition = transform.position.y;
		if(hangTrigger.name == "OnHangTrigger"){
			if(verticalDirection < 0){
				GetComponent<Rigidbody>().useGravity = true;
				Input.ResetInputAxes();
			}else if(verticalDirection > 0){
				xPosition = hangTrigger.transform.position.x - transform.lossyScale.x;
				yPosition = hangTrigger.transform.position.y + transform.lossyScale.y;
				Input.ResetInputAxes();
			}
		}

		//translate
		transform.position = new Vector3(xPosition, yPosition, 0);
	}



	//update is called once per delta
	void FixedUpdate(){
		
	}
=======

    //character's variable
    public GameObject player;
    //component variables
    Rigidbody playerRigidbody; //character's Rigidbody component
    PlayerStats playerStats; //character's stats
    void Change()
    {
        player.GetComponent<PlayerMovement>().enabled = !player.GetComponent<PlayerMovement>().enabled;
        player.GetComponent<Rigidbody>().useGravity = !player.GetComponent<Rigidbody>().useGravity;
       // player.GetComponent<HangMovement>().enabled = !player.GetComponent<HangMovement>().enabled;

    }

    void MoveUp()
    {
        
        float verticalDirection = Input.GetAxis("Vertical");
     

        if(verticalDirection <0)
        {
            Input.ResetInputAxes();
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<Rigidbody>().useGravity = true;

            Input.ResetInputAxes();

        }
        else if(verticalDirection>0)
        {
            Input.ResetInputAxes();
            {
                player.GetComponent<Transform>().position = new Vector3(transform.position.x + player.transform.lossyScale.x, transform.position.y + (2*player.transform.lossyScale.y), 0);
                player.GetComponent<PlayerMovement>().enabled = true;
                player.GetComponent<Rigidbody>().useGravity = true;
            }
            Input.ResetInputAxes();
            
            
        }
                     
    }

    void MoveDown()
    {
        float verticalDirection = Input.GetAxis("Vertical");
        

        if (verticalDirection < 0)
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Rigidbody>().useGravity = false;
            Input.ResetInputAxes();
            
            player.GetComponent<Transform>().position = new Vector3(transform.position.x - player.transform.lossyScale.x, transform.position.y - (2 * player.transform.lossyScale.y), 0);
            
            Input.ResetInputAxes();
           
        }

    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name=="OnHang")
        {
            MoveUp();
        }
        else if(other.gameObject.name == "AboveHang")
        {
            MoveDown();
        }

    }

    //use this for initialization
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerStats = GetComponent<PlayerStats>();
    }

    //update is called once per delta
    void FixedUpdate()
    {
        
    }
>>>>>>> 342fa9bd59544a9bea79d582b3a8fd15c97de27b
}
