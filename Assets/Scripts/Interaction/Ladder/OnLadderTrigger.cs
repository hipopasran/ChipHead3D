using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLadderTrigger : MonoBehaviour {

	//component variable
	public GameObject player;



	//switching scripts
	void Change(){
		player.GetComponent<PlayerMovement>().enabled = !player.GetComponent<PlayerMovement>().enabled;
		player.GetComponent<Rigidbody>().useGravity = !player.GetComponent<Rigidbody>().useGravity;
		player.GetComponent<LadderMovement>().enabled = !player.GetComponent<LadderMovement> ().enabled;
	}



	//when character enter the trigger collider
	void OnTriggerEnter(){
		Change();
	}
	
	//when character leave the trigger collider
	void OnTriggerExit(){
		Change();
	}
}
