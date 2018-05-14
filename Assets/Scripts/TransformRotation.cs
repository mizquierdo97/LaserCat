using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation= Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));

        int x = 0;
    }
}
