using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoint : MonoBehaviour {

	bool used = false; //if character wasn't on this trigger, then false

	void OnTriggerEnter(){
		if(!used){
			Debug.Log("Control point");
			used = !used;
			Destroy(gameObject);
		}else{
			Debug.Log("No!");
		}
	}

}
