
using UnityEngine;

public class PlayerLevel3Controller : PlayerController {

	protected override void Start() {
		
		_rb = GetComponent<Rigidbody2D>();
		_level = 2;

		base.Start();
	}
}
