using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour {


	RaycastHit hit;
    Ray ray;
    float MaxRange = 100;
	float Range = 100;

	LineRenderer line;
	Material lineMaterial;

	public Vector3 startPosition;
	Vector3 rayDirection = new Vector3(1,0,0);

	public bool reflect = false;
	public bool is_generator = false;


	GameObject collision_object = null;
    GameObject button_object = null;
    GameObject receptor_object = null;
    public int reflect_count = 0;

    //LAYERS
    int mirrorMask = 1 << 8;
    int wallMask = 1 << 9;
    int buttonMask = 1 << 10;
    int receptorMask = 1 << 11;

    void Start()
	{
		startPosition = new Vector3 (0, 0, 0);

		line = GetComponent<LineRenderer>();
		line.positionCount = 2;		
		line.startWidth = 0.5f;
		line.endWidth = 0.5f;
		//line.enabled = false;

	}

	void Update()
	{
       
        RestartValues();
      
		if (is_generator) {
			startPosition = transform.position;
			rayDirection = transform.forward;
		}
		if (reflect) {
			line.enabled = true;
			ray.direction = new Vector3(rayDirection.x,0, rayDirection.z);
            ray.direction = ray.direction.normalized;
	
            if (Physics.Raycast(startPosition, rayDirection, out hit, Mathf.Infinity, wallMask))
            {
                WallRay();
            }
         
            if (Physics.Raycast (startPosition, rayDirection, out hit, Range, mirrorMask)) {
                MirrorRay();
            }

            if (Physics.Raycast(startPosition, rayDirection, out hit, Range, buttonMask))
            {
                ButtonRay();
            }
            if (Physics.Raycast(startPosition, rayDirection, out hit, Range, receptorMask))
            {
                ReceptorRay();
            }

            line.SetPosition (0, startPosition);
			line.SetPosition (1, startPosition + rayDirection * Range);
            line.material.mainTextureScale = new Vector2(Range/5, 1);
            
        }
	   
	
	}

    void RestartValues()
    {
        line.enabled = false;
        reflect_count = 0;
        Range = 10000;
        if (collision_object != null)
        {
            RayScript ray_script = collision_object.GetComponent<RayScript>();
            ray_script.reflect = false;
            collision_object = null;

        }

    }

    void MirrorRay()
    {
        Range = hit.distance;
        collision_object = hit.collider.gameObject;
        RayScript ray_script = collision_object.GetComponent<RayScript>();

        if (reflect_count < 1)
        {
            ray_script.startPosition = hit.point;
            ray_script.rayDirection = Vector3.Reflect(rayDirection, hit.normal);
            ray_script.rayDirection = new Vector3(ray_script.rayDirection.x, 0, ray_script.rayDirection.z).normalized;
            ray_script.reflect = true;
            ray_script.reflect_count++;
        }
    }

    void ButtonRay()
    {
        Range = hit.distance;
        button_object = hit.collider.gameObject;
        ButtonScript button_script = button_object.GetComponent<ButtonScript>();

        button_script.activated = true;
    }

    void WallRay()
    {
        Range = hit.distance;
    }

    void ReceptorRay()
    {
        Range = hit.distance;
        receptor_object = hit.collider.gameObject;
        ReceptorScript receptor_script = receptor_object.GetComponent<ReceptorScript>();
        receptor_script.ChangeScene();


    }
}
