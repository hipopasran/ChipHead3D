using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangMovement : MonoBehaviour {
		
	int Direction(Collider hangTrigger){
		if(hangTrigger.transform.position.x < transform.position.x){
			return -1;
		}else{
			return 1;
		}
	}



	//while game object in the trigger colider
	void OnTriggerStay(Collider hangTrigger){
		//press button
		float verticalDirection = Input.GetAxis("Vertical");

		//positioning
		float xPosition = transform.position.x;
		float yPosition = transform.position.y;
		if(hangTrigger.name == "OnHangTrigger"){
			if(verticalDirection < 0){
				GetComponent<Rigidbody>().useGravity = true;
				Input.ResetInputAxes();
			}else if(verticalDirection > 0){
				xPosition = hangTrigger.transform.position.x + Direction(hangTrigger) * transform.lossyScale.x;
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
