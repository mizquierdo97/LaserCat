using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour {

    public int win_number;
    public int actual_buttons_pressed = 0;
    public string change_scene;
	// Use this for initialization
	void Start () {
        StopAllCoroutines();

    }
	
	// Update is called once per frame
	void Update () {
        if(actual_buttons_pressed >= win_number)
        {
            StopAllCoroutines();
            SceneManager.LoadScene(change_scene, LoadSceneMode.Single);
        }

        actual_buttons_pressed = 0;
	}
}
