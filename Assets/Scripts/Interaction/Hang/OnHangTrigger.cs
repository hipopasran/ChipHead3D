using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHangTrigger : MonoBehaviour {

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

}
