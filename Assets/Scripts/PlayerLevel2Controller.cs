
using UnityEngine;

public class PlayerLevel2Controller : PlayerController {

	protected override void Start() {
		
		_rb = GetComponent<Rigidbody2D>();
		_level = 1;

		base.Start();
	}
}
