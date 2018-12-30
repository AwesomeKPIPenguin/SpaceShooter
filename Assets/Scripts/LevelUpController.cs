using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpController : PowerUpController {

	protected override void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Player" && _isActive) {

			other.gameObject.SendMessage("LevelUp");
			base.OnTriggerEnter2D(other);
		}
	}
}
