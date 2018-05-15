using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour {

	Text text;
	public WinScript manager;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = manager.actual_buttons_pressed.ToString() + " / " + manager.win_number.ToString ();
	}
}
