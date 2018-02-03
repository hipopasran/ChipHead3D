using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveHangTrigger : MonoBehaviour {

	int Direction(Collider player){
		if(player.transform.position.x < transform.position.x){
			return 1;
		}else{
			return -1;
		}
	}



	//while game object in the trigger colider
	void OnTriggerStay(Collider player){
		//press button
		float verticalDirection = Input.GetAxis("Vertical");

		//check
		float xPosition = player.transform.position.x;
		float yPosition = player.transform.position.y;
		if(verticalDirection < 0){
			xPosition = GetComponentInParent<Transform>().position.x + Direction(player) * player.transform.lossyScale.x/2;
			yPosition = GetComponentInParent<Transform>().position.y - player.transform.lossyScale.y;
			Input.ResetInputAxes();
		}

		//translate
		player.GetComponent<Transform>().position = new Vector3(xPosition, yPosition, 0);
	}

}
