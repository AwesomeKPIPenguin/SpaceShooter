using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

    private Vector3 _moveVector;



    // Start is called before the first frame update
    void Start() {

        _moveVector = new Vector3(0.0f, -0.05f, 0.0f);
    }

    // Update is called once per frame
    void Update() {

        if (transform.position.y <= -9.0f)
            transform.position = new Vector3(0.0f, 0.0f, 0.0f);

        transform.position += _moveVector;
    }
}
