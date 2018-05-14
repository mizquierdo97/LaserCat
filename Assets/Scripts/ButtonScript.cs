using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    // Use this for initialization
    public GameObject door;
    public GameObject manager;
    public bool activated = false;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (activated)
        {
            if(door != null)
                door.GetComponent<DoorScript>().activated = true;
            if (manager != null)
                manager.GetComponent<WinScript>().actual_buttons_pressed++;
        }

        activated = false;
	}
}
