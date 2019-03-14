using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    GameManager _gm;

    private void Awake() {
        _gm = Object.FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.tag == "Player") {
            Debug.Log("Dead");
            _gm.Restart();
        }
    }
}
