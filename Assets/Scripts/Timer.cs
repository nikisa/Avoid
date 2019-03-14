﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime;
    public bool started = false;
    public bool finished = false;
    public float t;


    void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {        
        if (started) {            
            t = Time.time - startTime;
            Debug.Log(startTime);
        }
        if (finished) {
            return;
        }
        else {
            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            timerText.text = minutes + ":" + seconds;
        }
	}

    public void StopTimer() {
        finished = true;
        timerText.color = Color.green;
    }
}