using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour {

	//components
	public GameObject switchedObject;



	//when character enter the trigger collider
	void OnTriggerEnter(){
		switchedObject.GetComponent<OnOff>().enabled = true;
	}

	//when character leave the trigger collider
	void OnTriggerExit(){
		switchedObject.GetComponent<OnOff>().enabled = false;
	}

}
