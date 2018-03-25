using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSteamEnable : MonoBehaviour {

	public bool isActive;

    private void Update()
    {
    }
    // Use this for initialization
    private void OnTriggerStay(){
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            isActive = !isActive;
            Quaternion rotation = transform.rotation;
            rotation.x += 90f;
            transform.rotation = rotation;
        }
    }
}
