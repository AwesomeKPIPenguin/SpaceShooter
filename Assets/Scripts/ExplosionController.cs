
using System.Collections;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

	public	Sprite[]	Explosions;
	public	float		Interval;

	private	float		_lifetime;



	void Start() {

		_lifetime = Interval * Explosions.Length / 1000.0f;

		StartCoroutine(ChangeSprite());

		Destroy(gameObject, _lifetime);
	}

	IEnumerator ChangeSprite() {

		SpriteRenderer		renderer;

		renderer = GetComponent<SpriteRenderer>();

		foreach (Sprite explosion in Explosions) {

			renderer.sprite = explosion;
			yield return new WaitForSeconds(Interval / 1000.0f);
		}
	}
}
