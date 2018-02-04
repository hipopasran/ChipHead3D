using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveLadderTrigger : MonoBehaviour {

	int Direction(Collider player){
		if(player.transform.position.x > GetComponentInParent<Transform>().position.x){
			return -1;
		}else{
			return 1;
		}
	}



	//while game object in the trigger colider
	void OnTriggerStay(Collider player){
		//press button
		float verticalDirection = Input.GetAxis("Vertical");

		//positioning
		float xPosition = player.transform.position.x;
		float yPosition = player.transform.position.y;
		if(verticalDirection > 0 && !player.GetComponent<Stats>().isGrounded){
			xPosition = transform.position.x + Direction(player) * player.transform.lossyScale.x/2;
			yPosition = transform.position.y + player.transform.lossyScale.y;
			Input.ResetInputAxes();
		}else if(verticalDirection < 0 && player.GetComponent<Stats>().isGrounded){
			xPosition = GetComponentInParent<Transform>().position.x + Direction(player) * (GetComponentInParent<Transform>().lossyScale.x/2 + player.transform.lossyScale.x/2);
			yPosition = transform.position.y - player.transform.lossyScale.y;
			Input.ResetInputAxes();
		}
			
		//translate
		player.GetComponent<Transform>().position = new Vector3(xPosition, yPosition, 0);
	}

}
