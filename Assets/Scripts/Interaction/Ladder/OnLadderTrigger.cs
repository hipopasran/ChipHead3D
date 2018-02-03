using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLadderTrigger : MonoBehaviour {

	//switching scripts
	void Change(Collider player){
		player.GetComponent<GroundMovement>().enabled = !player.GetComponent<GroundMovement>().enabled;
		player.GetComponent<Stats>().enabled = !player.GetComponent<Stats>().enabled; //this
		player.GetComponent<Stats>().enabled = !player.GetComponent<Stats>().enabled; //and this shit are need
		player.GetComponent<Rigidbody>().useGravity = !player.GetComponent<Rigidbody>().useGravity;
		player.GetComponent<LadderMovement>().enabled = !player.GetComponent<LadderMovement>().enabled;
	}



	//when character enter the trigger collider
	void OnTriggerEnter(Collider player){
		Change(player);
		Input.ResetInputAxes();
	}
	
	//when character leave the trigger collider
	void OnTriggerExit(Collider player){
		Change(player);
		Input.ResetInputAxes();
	}
}
