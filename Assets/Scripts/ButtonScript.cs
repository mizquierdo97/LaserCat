using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    // Use this for initialization
    public GameObject door;
    public bool activated = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (activated)
        {
            door.GetComponent<DoorScript>().activated = true;
        }

        activated = false;
	}
}
