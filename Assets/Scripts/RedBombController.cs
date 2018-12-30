using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBombController : EnemyShotController {
    
	protected override void Start() {

		Vector2	rand;
		float	xBound;
		float	yBound;

		rand = Random.insideUnitCircle.normalized;
		xBound = Mathf.Sin(Mathf.PI / 6);
		yBound = Mathf.Cos(Mathf.PI / 6);

		// this two rotations will ensure x in needed bounds

		if (Mathf.Abs(rand.x) > xBound)
			rand = Quaternion.Euler(0.0f, 0.0f, 60.0f) * rand;
		if (Mathf.Abs(rand.x) > xBound)
			rand = Quaternion.Euler(0.0f, 0.0f, 60.0f) * rand;

		// fit the y bounds

		if (rand.y < 0)
			rand = new Vector2(rand.x, -rand.y);

		//

		_moveVector = rand * (Speed / _slower);
	}
}
