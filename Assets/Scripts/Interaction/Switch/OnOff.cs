using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour {

	void Update(){
		if(Input.GetButtonDown("Interaction")){
			if(transform.name == "Lamp"){
				transform.GetComponent<Light>().enabled = !transform.GetComponent<Light>().enabled;
			}
		}
	}

}
