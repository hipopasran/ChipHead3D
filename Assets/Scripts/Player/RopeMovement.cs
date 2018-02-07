using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMovement : MonoBehaviour {

    int swingForce = 25;
    float speed;

    //components
    Rigidbody playerRigidbody; //character's Rigidbody
    Stats playerStats; //character's stats

  

    void Move()
    {
        float verticalDirection = Input.GetAxis("Vertical");
        float horizontalDirection = Input.GetAxis("Horizontal");

        if (horizontalDirection > 0)
        {
            playerRigidbody.AddForce(transform.right * swingForce);
        }
        else if(horizontalDirection<0)
        {
            playerRigidbody.AddForce(transform.right * -swingForce);
        }
        if(verticalDirection>0)
        {
            Destroy(GetComponent<HingeJoint>());
            //playerRigidbody.AddForce(transform.up * playerStats.jump);
            playerRigidbody.AddForce(new Vector3(0, playerStats.jump, 0), ForceMode.Impulse);
            StartCoroutine(Wait());
            GetComponent<Stats>().swinging = false;
        }
        if(verticalDirection<0)
        {
            Destroy(GetComponent<HingeJoint>());
            
            StartCoroutine(Wait());
            GetComponent<Stats>().swinging = false;


        }
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(100f);
        //GetComponent<Stats>().swinging = false;
        GetComponent<Stats>().enabled = !GetComponent<Stats>().enabled; //this
        GetComponent<Stats>().enabled = !GetComponent<Stats>().enabled; //and this shit are need
    }

    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerStats = GetComponent<Stats>();

    }

    //update is called once per delta
    void FixedUpdate()
    {
        Move();
    }


}
