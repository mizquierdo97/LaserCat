using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    // Use this for initialization
    public GameObject door;
    public GameObject manager;
    public bool activated = false;
    public bool sound_played = false;
    public AudioSource a_source;
    public AudioClip clip;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (activated)
        {
            if(a_source.isPlaying == false && sound_played == false)
            {
                a_source.PlayOneShot(clip);
                sound_played = true;
            }
           
            if(door != null)
                door.GetComponent<DoorScript>().activated = true;
            if (manager != null)
                manager.GetComponent<WinScript>().actual_buttons_pressed++;
        }
        if(activated == false)
        {
            sound_played = false;
        }
        activated = false;
	}
}
