
using System.Collections;
using UnityEngine;

public class EnemyLightController : EnemyController {

	protected override void Start() {
		
		base.Start();

		_rb = GetComponent<Rigidbody2D>();
	}

	protected override void FixedUpdate() {

		base.FixedUpdate();

		_rb.velocity = new Vector2(0, 1) * Speed;
	}



	static public IEnumerator SpawnWave(GameObject enemy, float delay) {
		
		for (int i = 0; i < 5; ++i) {

			InstantiateAtRandom(enemy);
			yield return new WaitForSeconds(1.5f);
		}
		yield return new WaitForSeconds(delay);
	}
}
