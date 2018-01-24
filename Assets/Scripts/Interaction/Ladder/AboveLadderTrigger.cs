using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveLadderTrigger : MonoBehaviour {

	//component variable
	public GameObject player;



	//switching scripts
	void Change(){
		player.GetComponent<PlayerMovement>().enabled = !player.GetComponent<PlayerMovement>().enabled;
		player.GetComponent<Rigidbody>().useGravity = !player.GetComponent<Rigidbody>().useGravity;
		player.GetComponent<LadderMovement>().enabled = !player.GetComponent<LadderMovement>().enabled;
	}



	//when character enter the trigger collider
	void OnTriggerEnter(){
		if(!player.GetComponent<PlayerStats>().onLadder){
			player.GetComponent<Transform>().position = new Vector3(transform.position.x - transform.lossyScale.x, transform.position.y - player.transform.lossyScale.y, 0);
		}else{
			player.GetComponent<Transform>().position = new Vector3(transform.position.x + player.transform.lossyScale.x, transform.position.y, 0);
		}
		Change();
	}

	//when character leave the trigger collider
	void OnTriggerExit(){
		Change();
	}
}
