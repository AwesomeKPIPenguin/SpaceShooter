
using UnityEngine;

public class PlayerLevel1Controller : PlayerController {
   
	protected override void Start() {
		
		_rb = GetComponent<Rigidbody2D>();
		_level = 0;

		base.Start();
	}
}
