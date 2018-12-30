
using System;
using UnityEngine;

public class ShipController : MonoBehaviour {
    
	protected	Rigidbody2D		_rb;
	protected	float			_slower;
	protected	DateTime		_lastShot;
	protected	bool			_isDisarmed;

	public		GameObject		Shot;
	public		GameObject[]	ShotSpawns;
	public		int				HP;
	public		float			Speed;
	public		float			CD;



	protected virtual void Start() {

		_slower = 10.0f;
		_lastShot = new DateTime(0);
		_isDisarmed = false;
	}

	protected virtual void Update() {

	}

	protected virtual void FixedUpdate() {

	}



	protected void Shoot() {

		Vector3	pos;

		if (_isDisarmed)
			return ;

		pos = transform.position;

		if ((DateTime.Now.Ticks - _lastShot.Ticks - CD * 10000) >= 0) {

			_lastShot = DateTime.Now;
			
			foreach (GameObject shotSpawn in ShotSpawns)
				Instantiate(
					Shot,
					shotSpawn.transform.position + pos,
					shotSpawn.transform.rotation
				);
		}
	}

	public void TakeDamage(int damage) {

		int		rand;

		HP -= damage;

		if (HP <= 0) {

			if (tag == "Enemy") {

				rand = UnityEngine.Random.Range(0, 99);

				if (rand < 30) {

					Instantiate(
						(rand % 2 == 0) ?
							Resources.Load("PowerUps/PowerUpLevel") :
							Resources.Load("PowerUps/PowerUpLife"),
						transform.position,
						transform.rotation
					);
				}
			}

			Instantiate(Resources.Load("Effects/ShipExplosion"), transform.position, transform.rotation);

			Destroy(gameObject);
		}
	}

	public void Disarm() {

		_isDisarmed = true;
	}
}
