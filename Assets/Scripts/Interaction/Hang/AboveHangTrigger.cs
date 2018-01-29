using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveHangTrigger : MonoBehaviour {
    //component variable
    public GameObject player;



    //switching scripts
    void Change()
    {
       // player.GetComponent<PlayerMovement>().enabled = !player.GetComponent<PlayerMovement>().enabled;
        //player.GetComponent<Rigidbody>().useGravity = !player.GetComponent<Rigidbody>().useGravity;
        //player.GetComponent<HangMovement>().enabled = !player.GetComponent<HangMovement>().enabled;
    }



    //when character enter the trigger collider
    void OnTriggerEnter()
    {
        
        Change();
        player.GetComponent<HangMovement>().enabled = true;
    }

    //when character leave the trigger collider
    void OnTriggerExit()
    {
        Change();
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<HangMovement>().enabled = false;
    }
}
