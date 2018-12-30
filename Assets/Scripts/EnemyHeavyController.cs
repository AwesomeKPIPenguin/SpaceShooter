using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeavyController : EnemyController {
   
	protected override void Start() {
		
		base.Start();

		_rb = GetComponent<Rigidbody2D>();
	}

	protected override void FixedUpdate() {

		base.FixedUpdate();

		if (transform.position.y > 4.0f)
			_rb.velocity = new Vector2(0, 1) * Speed;
		else
			transform.position = new Vector3(transform.position.x, 4.0f, 0.0f);
	}



	static public IEnumerator SpawnWave(GameObject enemy, float delay) {
		
		for (int i = 0; i < 5; ++i) {

			Instantiate(enemy, new Vector3(-2.0f + i, 4.5f, 0.0f), enemy.transform.rotation);
			yield return new WaitForSeconds(1.3f);
		}

		yield return new WaitForSeconds(delay);
	}
}
