using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMediumController : EnemyController {
    
	protected override void Start() {
		
		base.Start();

		_rb = GetComponent<Rigidbody2D>();
	}

	protected override void FixedUpdate() {

		base.FixedUpdate();

		_rb.velocity = new Vector2(0, 1) * Speed;
	}



	static public IEnumerator SpawnWave(GameObject enemy, float delay) {
		
		Instantiate(enemy, new Vector3(0.0f, 5.0f, 0.0f), enemy.transform.rotation);
		yield return new WaitForSeconds(1.5f);
		Instantiate(enemy, new Vector3(-1.0f, 5.0f, 0.0f), enemy.transform.rotation);
		Instantiate(enemy, new Vector3(1.0f, 5.0f, 0.0f), enemy.transform.rotation);
		yield return new WaitForSeconds(1.5f);
		Instantiate(enemy, new Vector3(-2.0f, 5.0f, 0.0f), enemy.transform.rotation);
		Instantiate(enemy, new Vector3(2.0f, 5.0f, 0.0f), enemy.transform.rotation);
		yield return new WaitForSeconds(1.5f);

		yield return new WaitForSeconds(delay);
	}
}
