using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target; //camera's target
	public float smoothing; //speed of camera's movement, delay

	Vector3 offset; //distance from target to camera



	//use this for initialization
	void Start(){
		offset = transform.position - target.position;
	}
	
	//update is called once per delta
	void FixedUpdate(){
		Vector3 newCameraPosition = target.position + offset;

		transform.position = Vector3.Lerp(transform.position, newCameraPosition, smoothing * Time.deltaTime);
	}

}
