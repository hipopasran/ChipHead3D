using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlledPush : MonoBehaviour {

    Vector3 tempScale;
	public Transform childTransform;
	Vector3 startScale;
	public bool isActive;
	// Use this for initialization
	void Start () {
		childTransform = this.gameObject.transform.Find("WhiteSmoke");
		startScale = childTransform.localScale;
        isActive = GetComponentInChildren<SwitchSteamEnable>().isActive;
        Debug.Log("IsActive " + isActive);
    }
	
    private void OnTriggerEnter(Collider other)
    {
        isActive = GetComponentInChildren<SwitchSteamEnable>().isActive;
        if (isActive) {
			childTransform = this.gameObject.transform.GetChild (0);
			if (other.gameObject.CompareTag ("Player")) {
				// Push player upward
				other.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000f,ForceMode.Force);

				// Change steam intensity
				tempScale = childTransform.localScale;
				tempScale.x += 2f;
				this.gameObject.transform.Find("WhiteSmoke").localScale = tempScale;
				

			}
		}
    }
	private void OnTriggerExit(){
	
		 //Reset scale of steam
		this.gameObject.transform.transform.Find("WhiteSmoke").localScale= startScale;
	}
}
