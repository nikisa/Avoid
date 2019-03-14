using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour {

    Timer timer;

    private void Awake() {
        timer = Object.FindObjectOfType<Timer>().GetComponent<Timer>();
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.tag == "Player") {
            Debug.Log("Win");
            timer.StopTimer();
        }
    }
}
