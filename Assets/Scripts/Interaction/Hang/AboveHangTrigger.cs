using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveHangTrigger : MonoBehaviour {

	//while game object in the trigger colider
	void OnTriggerStay(Collider player){
		//press button
		float verticalDirection = Input.GetAxis("Vertical");

		//check
		float xPosition = player.transform.position.x;
		float yPosition = player.transform.position.y;
		if(verticalDirection < 0 && player.GetComponent<Stats>().isGrounded){
			xPosition = transform.position.x + player.GetComponent<Transform>().lossyScale.x - 0.5f;
			yPosition = transform.position.y - player.GetComponent<Transform>().lossyScale.y;
			Input.ResetInputAxes();
		}

		//translate
		player.GetComponent<Transform>().position = new Vector3(xPosition, yPosition, 0);
	}

}
