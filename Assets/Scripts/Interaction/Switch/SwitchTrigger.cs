using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour {

	//components
	GameObject switchedObject;



	void OnTriggerEnter(){
		switchedObject.GetComponent<OnOff>().enabled = true;
	}

	void OnTriggerExit(){
		switchedObject.GetComponent<OnOff>().enabled = false;
	}



	void Awake(){
		switchedObject = transform.parent.GetChild(transform.parent.childCount - 1).gameObject;
	}
}
