using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMirror : MonoBehaviour {

    public GameObject Map;
    public float Offset = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       if( transform.position.y <  (Map.transform.position.y + Offset) - 0.2f)
        transform.localPosition = new Vector3(0, transform.localPosition.y+0.05f, 0);
       else if (transform.position.y > (Map.transform.position.y + Offset) + 0.2f)
            transform.localPosition = new Vector3(0, transform.localPosition.y - 0.05f, 0);
        //transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    }
}
