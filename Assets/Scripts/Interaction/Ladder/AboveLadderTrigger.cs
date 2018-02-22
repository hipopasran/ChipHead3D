using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveLadderTrigger : MonoBehaviour {

	//need to choice of direction
	int Direction(Collider player){
		if(transform.position.x > GetComponentInParent<Transform>().position.x){
			return 1;
		}else{
			return -1;
		}
	}



	void OnTriggerStay(Collider player){
		//press button
		float verticalDirection = Input.GetAxis("Vertical");

		//positioning
		float xPosition = player.transform.position.x;
		float yPosition = player.transform.position.y;
		if(verticalDirection > 0 && !player.GetComponent<Stats>().isGrounded){
			//if player was pressed up
			xPosition = transform.position.x - Direction(player) * player.transform.lossyScale.x/2;
			yPosition = transform.position.y + player.transform.lossyScale.y;
			Input.ResetInputAxes();
		}else if(verticalDirection < 0 && player.GetComponent<Stats>().isGrounded){
			//if player was pressed down
			xPosition = GetComponentInParent<Transform>().position.x + Direction(player) * player.transform.lossyScale.x/2;
			yPosition = transform.position.y - player.transform.lossyScale.y;
			Input.ResetInputAxes();
		}
			
		//translate
		player.GetComponent<Transform>().position = new Vector3(xPosition, yPosition, 0);
	}

}
