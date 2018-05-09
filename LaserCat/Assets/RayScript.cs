using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayScript : MonoBehaviour {

	Vector2 mouse;
	RaycastHit hit;
	float MaxRange = 100;
	float Range = 100;
	LineRenderer line;
	Material lineMaterial;
	Ray ray;
	public Vector3 startPosition;
	Vector3 rayDirection = new Vector3(1,0,0);
	public bool reflect = false;
	public bool is_generator = false;
	GameObject collision_object = null;
	void Start()
	{
		startPosition = new Vector3 (0, 0, 0);
		lineMaterial = GetComponent<Material> ();
		line = GetComponent<LineRenderer>();
		line.positionCount = 2;
		line.material = lineMaterial;
		line.startWidth = 0.25f;
		line.endWidth = 0.25f;
		//line.enabled = false;

	}

	void Update()
	{
		if (is_generator)
			startPosition = transform.position;
		if (reflect) {
			line.enabled = true;

			ray.direction = rayDirection;
			int mirrorMask = 1 << 8;
			int wallMask =1 << 9;
			RaycastHit hit;
			// Does the ray intersect any objects excluding the player layer
			if (Physics.Raycast (startPosition, rayDirection, out hit, Mathf.Infinity, mirrorMask)) {
				Range = hit.distance;
				collision_object = hit.collider.gameObject;
				RayScript ray_script = collision_object.GetComponent<RayScript> ();
				ray_script.startPosition = hit.point;
				ray_script.rayDirection = Vector3.Reflect (rayDirection, hit.normal);
				ray_script.reflect = true;
			}
			else if (Physics.Raycast (startPosition, rayDirection, out hit, Mathf.Infinity, wallMask)) {
				Range = hit.distance;

			}
			else {
				Range = 10000;
				if (collision_object != null) {
					RayScript ray_script = collision_object.GetComponent<RayScript> ();
					ray_script.reflect = false;
				}
			}	

			line.SetPosition (0, startPosition);
			line.SetPosition (1, startPosition + rayDirection * Range);

		}

			else{
			line.enabled = false;
		
	
			}
	
	}
}
