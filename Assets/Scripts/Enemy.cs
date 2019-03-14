using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public bool clockwise = true;
    public float speed = 0;

	// Update is called once per frame
	void Update () {

        if (clockwise) {
            transform.Rotate(new Vector3(0, 0, -1) * (Time.deltaTime * speed));
        }
        else {
            transform.Rotate(new Vector3(0, 0, 1) * (Time.deltaTime * speed));
        }
    }
}
