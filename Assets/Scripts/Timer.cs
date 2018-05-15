using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour {

	Text timer;
	float miliseconds = 0;
	// Use this for initialization
	void Start () {
		timer = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		miliseconds += Time.deltaTime * 100;
		miliseconds = miliseconds % 100;
		timer.text = (((int)Time.timeSinceLevelLoad)%60).ToString () + " : " + ((int)miliseconds).ToString ();
	}
}
