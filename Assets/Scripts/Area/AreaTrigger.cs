using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTrigger : MonoBehaviour {

	//check
	public string kind; //kind number of area



	//when character enter the trigger collider
	void OnTriggerEnter(Collider player){
		if(kind == "glass"){
			player.GetComponent<Stats>().glass = true;
		}
	}

	//when character leave the trigger collider
	void OnTriggerExit(Collider player){
		player.GetComponent<Stats>().glass = false;
	}
}
