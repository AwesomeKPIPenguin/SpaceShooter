
using System.Collections;
using UnityEngine;

public class EnemyController : ShipController {

	protected override void FixedUpdate() {

		base.FixedUpdate();

		Shoot();
	}



	static protected void InstantiateAtRandom(GameObject enemy) {

		Instantiate(
			enemy,
			new Vector3(Random.Range(-2.5f, 2.5f), 4.75f, 0.0f),
			enemy.transform.rotation
		);
	}
}
