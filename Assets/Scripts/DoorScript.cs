using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public bool activated = false;
    float max_dist = 10;
    Vector3 start_position;
	// Use this for initialization
	void Start () {
        start_position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (activated)
        {
            Move();
        }
        else
        {
            ReturnInitialPos();
        }

        activated = false;

	}
    void Move()
    {
        float final_pos = start_position.y - max_dist;
        float actual_pos = transform.position.y;
        if(actual_pos > final_pos)
        {
            float y = actual_pos - Time.deltaTime * 4.0f;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
    }
    void ReturnInitialPos()
    {
        float final_pos = start_position.y;
        float actual_pos = transform.position.y;
        if (actual_pos < final_pos)
        {
            float y = actual_pos + Time.deltaTime * 4.0f;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }

    }
}
