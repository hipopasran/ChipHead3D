using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveLadderTrigger : MonoBehaviour {

	//while game object in the trigger colider
	void OnTriggerStay(Collider player){
		//press button
		float verticalDirection = Input.GetAxis("Vertical");

		//check
		float xPosition = player.transform.position.x;
		float yPosition = player.transform.position.y;
		if(verticalDirection > 0 && player.GetComponent<Stats>().onLadder){
			xPosition = transform.position.x + player.transform.lossyScale.x/2;
			yPosition = transform.position.y + player.transform.lossyScale.y;
			Input.ResetInputAxes();
		}else if(verticalDirection < 0 && player.GetComponent<Stats>().isGrounded){
			xPosition = transform.position.x - transform.lossyScale.x;
			yPosition = transform.position.y - player.transform.lossyScale.y;
			Input.ResetInputAxes();
		}
			
		//translate
		player.GetComponent<Transform>().position = new Vector3(xPosition, yPosition, 0);
	}

}
