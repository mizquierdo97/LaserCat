using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReceptorScript : MonoBehaviour {

    public string change_scene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeScene()
    {
        SceneManager.LoadScene(change_scene, LoadSceneMode.Single);
    }
}
