using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour {

	//check
	public short kind; //kind number of ineraction object
	enum Kind : short {light};

	//use this for initialization
	void Update(){
		if(Input.GetButtonUp("Interaction")){
			if(kind == (short)Kind.light){
				gameObject.GetComponent<Light>().enabled = !gameObject.GetComponent<Light>().enabled;
			}
		}
	}

}
