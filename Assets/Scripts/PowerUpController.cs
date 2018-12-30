using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {
	
	public		float	Speed;

	protected	Vector3	_movement;
	protected	bool	_isActive;



	void Start() {

		_movement = new Vector3(0.0f, Speed, 0.0f);
		_isActive = true;
	}

	void Update() {

	}

	void FixedUpdate() {

		transform.position = transform.position + _movement;
	}



	protected virtual void OnTriggerEnter2D(Collider2D other) {
		
		AudioSource	audio;

		audio = GetComponent<AudioSource>();
		audio.Play();
		_isActive = false;
		Destroy(gameObject, audio.clip.length);
	}
}
