using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveHangTrigger : MonoBehaviour {
<<<<<<< HEAD

	//while game object in the trigger colider
	void OnTriggerStay(Collider player){
		//press button
		float verticalDirection = Input.GetAxis("Vertical");

		//check
		float xPosition = player.transform.position.x;
		float yPosition = player.transform.position.y;
		if(verticalDirection < 0 && player.GetComponent<Stats>().isGrounded){
			xPosition = transform.position.x + player.GetComponent<Transform>().lossyScale.x - 0.5f;
			yPosition = transform.position.y - player.GetComponent<Transform>().lossyScale.y;
			Input.ResetInputAxes();
		}

		//translate
		player.GetComponent<Transform>().position = new Vector3(xPosition, yPosition, 0);
	}

=======
    //component variable
    public GameObject player;



    //switching scripts
    void Change()
    {
       // player.GetComponent<PlayerMovement>().enabled = !player.GetComponent<PlayerMovement>().enabled;
        //player.GetComponent<Rigidbody>().useGravity = !player.GetComponent<Rigidbody>().useGravity;
        //player.GetComponent<HangMovement>().enabled = !player.GetComponent<HangMovement>().enabled;
    }



    //when character enter the trigger collider
    void OnTriggerEnter()
    {
        
        Change();
        player.GetComponent<HangMovement>().enabled = true;
    }

    //when character leave the trigger collider
    void OnTriggerExit()
    {
        Change();
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<HangMovement>().enabled = false;
    }
>>>>>>> 342fa9bd59544a9bea79d582b3a8fd15c97de27b
}
