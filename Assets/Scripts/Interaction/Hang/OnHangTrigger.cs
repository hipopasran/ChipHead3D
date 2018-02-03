using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHangTrigger : MonoBehaviour {

<<<<<<< HEAD
	//switching scripts
	void Change(Collider player){
		player.GetComponent<GroundMovement>().enabled = !player.GetComponent<GroundMovement>().enabled;
		player.GetComponent<Stats>().enabled = !player.GetComponent<Stats>().enabled; //this
		player.GetComponent<Stats>().enabled = !player.GetComponent<Stats>().enabled; //and this shit are need
		player.GetComponent<Rigidbody>().useGravity = !player.GetComponent<Rigidbody>().useGravity;
		player.GetComponent<HangMovement>().enabled = !player.GetComponent<HangMovement>().enabled;
	}



	//when character enter the trigger collider
	void OnTriggerEnter(Collider player){
		Change(player);
		player.GetComponent<Rigidbody>().velocity = Vector3.zero;
		Input.ResetInputAxes();
	}

	//when character leave the trigger collider
	void OnTriggerExit(Collider player){
		Change(player);
		player.GetComponent<Rigidbody>().useGravity = true;
		Input.ResetInputAxes();
	}

=======
    //component variable
    public GameObject player;



    //switching scripts
    void Change()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Rigidbody>().useGravity = false;
        
    }



    //when character enter the trigger collider
    void OnTriggerEnter()
    {
       
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        Input.ResetInputAxes();
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<HangMovement>().enabled = true;
    }

    //when character leave the trigger collider
    void OnTriggerExit()
    {
        // Change();
        player.GetComponent<HangMovement>().enabled = false;
    }
>>>>>>> 342fa9bd59544a9bea79d582b3a8fd15c97de27b
}
