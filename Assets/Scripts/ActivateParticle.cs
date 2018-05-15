using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateParticle : MonoBehaviour {

	public int particle_num;
	public WinScript win;

	ParticleSystem emitter;
	// Use this for initialization
	void Start () {
		emitter = GetComponent<ParticleSystem> ();
		emitter.Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		if (win.actual_buttons_pressed >= particle_num) {
			emitter.Play ();
		}
	}
}
