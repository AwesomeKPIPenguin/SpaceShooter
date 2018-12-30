using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour {

	static protected	float	_slower;

	protected			Vector3	_moveVector;

	public				int		Damage;
	public				float	Speed;



	static ShotController() {

		_slower = 10.0f;
	}



	protected virtual void Start() {

		_moveVector = new Vector3(0.0f, Speed / _slower, 0.0f);
	}

	void Update() {

	}

	void FixedUpdate() {

		transform.position += _moveVector;
	}



	protected virtual void OnTriggerEnter2D(Collider2D other) { }

	protected bool IsTrigger(Collider2D other) =>
		(other.gameObject.tag != "Shot" && other.gameObject.tag != "Boundary");
}
