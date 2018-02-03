using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	//camera
	public float smoothing; //speed of camera's movement, delay
	public float offset; //distance from target to the camera

	//components
	Transform target; //camera's target



	//use this for initialization
	void Awake(){
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	//update is called once per delta
	void FixedUpdate(){
		Vector3 newCameraPosition = new Vector3(target.position.x, target.position.y, target.position.z + offset);

		transform.position = Vector3.Lerp(transform.position, newCameraPosition, smoothing * Time.deltaTime);
	}

}
