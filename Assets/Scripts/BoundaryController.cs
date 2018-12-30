
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour {

	void Start() {

	}

	void Update() {

	}

	void OnTriggerExit2D(Collider2D other) {

		if (other.tag == "Player")
			return ;

		Destroy(other.gameObject);
	}
}
