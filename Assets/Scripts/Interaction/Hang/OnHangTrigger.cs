using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHangTrigger : MonoBehaviour {

    //component variable
    public GameObject player;



    //switching scripts
    void Change()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Rigidbody>().useGravity = false;
        
    }



    //when character enter the trigger collider
    void OnTriggerEnter()
    {
       
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        Input.ResetInputAxes();
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<HangMovement>().enabled = true;
    }

    //when character leave the trigger collider
    void OnTriggerExit()
    {
        // Change();
        player.GetComponent<HangMovement>().enabled = false;
    }
}
