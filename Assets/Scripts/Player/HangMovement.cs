using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangMovement : MonoBehaviour {
		
	int Direction(Collider hangTrigger){
		float aboveHangCollider = hangTrigger.transform.parent.Find("AboveHangTrigger").transform.position.x;
		float parentCollider = hangTrigger.GetComponentInParent<Transform>().position.x;

		if(aboveHangCollider > parentCollider){
			return 1;
		}else{
			return -1;
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
				xPosition = hangTrigger.GetComponentInParent<Transform>().position.x + Direction(hangTrigger) * transform.lossyScale.x;
				yPosition = hangTrigger.GetComponentInParent<Transform>().position.y + transform.lossyScale.y;
				Input.ResetInputAxes();
			}
		}else if(hangTrigger.name == "AboveHangTrigger"){
			if(verticalDirection < 0){
				xPosition = hangTrigger.GetComponentInParent<Transform>().position.x - Direction (hangTrigger) * transform.lossyScale.x/2;
				yPosition = hangTrigger.GetComponentInParent<Transform>().position.y - transform.lossyScale.y;
				Input.ResetInputAxes();
				Debug.Log(transform.lossyScale.x/2);
			}
		}

		//translate
		transform.position = new Vector3(xPosition, yPosition, 0);
	}



	//update is called once per delta
	void FixedUpdate(){
		
	}
}
