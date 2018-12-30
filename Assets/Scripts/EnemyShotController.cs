
using UnityEngine;

public class EnemyShotController : ShotController {

	protected override void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Player")
			other.gameObject.SendMessage("TakeDamage", Damage);
		if (!IsTrigger(other) || other.gameObject.tag == "Enemy")
			return ;

		Destroy(gameObject);
		Instantiate(Resources.Load("Effects/HitExplosion"), transform.position, transform.rotation);
	}
}
