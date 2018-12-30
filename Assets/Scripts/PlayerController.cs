
using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerController : ShipController {

	public		Text			Label;
	protected	int				_level;

	private		float			_xMin, _xMax;
	private		float			_yMin, _yMax;

	public		int				Level {

		get { return (_level); }
		set {
			_level = Mathf.Clamp(value, 0, 2);

			// instantiating necessary model

			Instantiate(Models[_level], transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
	public		GameObject[]	Models;



	protected override void Start() {

		base.Start();

		Label = GameObject.Find("Canvas/HPLabel").GetComponent<Text>();

		_slower = 10.0f;
		_xMin = -2.7f;
		_xMax = 2.7f;
		_yMin = -4.3f;
		_yMax = 2.0f;
		_lastShot = new DateTime(0);
	}

	protected override void FixedUpdate() {

		float x;
		float y;

		base.FixedUpdate();

		Label.text = "HP: " + HP;

		// moving

		x = Input.GetAxis("Horizontal");
		y = Input.GetAxis("Vertical");

		_rb.velocity = new Vector2(x, y) * Speed;

		if (transform.position.x < _xMin || transform.position.x > _xMax ||
			transform.position.y < _yMin || transform.position.y > _yMax) {
			
			transform.position = new Vector2(
				Mathf.Clamp(transform.position.x, _xMin, _xMax),
				Mathf.Clamp(transform.position.y, _yMin, _yMax)
			);
		}

		// shooting

		if (Input.GetButton("Jump"))
			Shoot();
	}



	public new void TakeDamage(int damage) {

		HP -= damage;

		if (HP <= 0) {
			
			Instantiate(Resources.Load("Effects/ShipExplosion"), transform.position, transform.rotation);
			GameObject.Find("GameController").SendMessage("Lose");
			Destroy(gameObject);
		}
	}

	public void LevelUp() {

		if (Level != 2)
			++Level;
	}

	public void AddLife() {

		++HP;
	}
}
