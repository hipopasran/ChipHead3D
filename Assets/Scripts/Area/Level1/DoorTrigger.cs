using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour {

	bool used = false; //if character wasn't on this trigger, then false

	void OnTriggerEnter(){
		if(!used){
			Debug.Log("Animation with shadow");
			used = !used;
			Destroy(gameObject);
		}else{
			Debug.Log("No!");
		}
	}

}
