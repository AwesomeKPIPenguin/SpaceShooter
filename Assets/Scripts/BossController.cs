using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController {

	public	Transform[]	ExplosionSpots;

	private	bool		_isDead;



	protected override void Start() {
		
		base.Start();

		_isDead = false;
		_rb = GetComponent<Rigidbody2D>();
		GameObject.Find("Background").GetComponent<AudioSource>().Stop();
	}

	protected override void FixedUpdate() {

		base.FixedUpdate();

		if (!_isDead) {

			if (transform.position.y > 3.2f)
				_rb.velocity = new Vector2(0, 1) * Speed;
			else
				transform.position = new Vector3(transform.position.x, 3.2f, 0.0f);
		}
	}



	static public IEnumerator SpawnWave(GameObject enemy, float delay) {
		
		Instantiate(enemy, new Vector3(0.0f, 5.75f, 0.0f), enemy.transform.rotation);
		yield return new WaitForSeconds(0);
	}

	public new void TakeDamage(int damage) {

		if (_isDead)
			return ;

		HP -= damage;

		if (HP <= 0) {

			GetComponent<AudioSource>().Stop();
			StartCoroutine(StartExplosions());
			
			// disarming boss and player
			
			Disarm();
			GameObject player = GameObject.Find("PlayerLevel1(Clone)");
			if (player == null)
				player = GameObject.Find("PlayerLevel2(Clone)");
			if (player == null)
				player = GameObject.Find("PlayerLevel3(Clone)");
			player.SendMessage("Disarm");
			GameObject.Find("GameController").SendMessage("Win");
		}
	}

	private IEnumerator StartExplosions() {

		while (true) {

			if (!_isDead)
				_rb.AddForce(new Vector2(0.0f, 0.005f));

			_isDead = true;
			foreach (Transform t in ExplosionSpots) {

				Instantiate(Resources.Load("Effects/ShipExplosion"), t.position, t.rotation);
				yield return new WaitForSeconds(0.2f);
			}
		}
	}
}
