using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotController : ShotController {

	protected override void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Enemy")
			other.gameObject.SendMessage("TakeDamage", Damage);
		if (!IsTrigger(other) || other.gameObject.tag == "Player")
			return ;

		Destroy(gameObject);
		Instantiate(Resources.Load("Effects/HitExplosion"), transform.position, transform.rotation);
	}
}
