using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangMovement : MonoBehaviour {
		
	//while game object in the trigger colider
	void OnTriggerStay(Collider hangTrigger){
		//press button
		float verticalDirection = Input.GetAxis("Vertical");

		//check
		float xPosition = transform.position.x;
		float yPosition = transform.position.y;
		if(hangTrigger.name == "OnHangTrigger"){
			if(verticalDirection < 0){
				GetComponent<Rigidbody>().useGravity = true;
				Input.ResetInputAxes();
			}else if(verticalDirection > 0){
				xPosition = hangTrigger.transform.position.x - transform.lossyScale.x;
				yPosition = hangTrigger.transform.position.y + transform.lossyScale.y;
				Input.ResetInputAxes();
			}
		}

		//translate
		transform.position = new Vector3(xPosition, yPosition, 0);
	}



	//update is called once per delta
	void FixedUpdate(){
		
	}
}
