﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject ball;
    public float lerpRate;
    
    Vector3 offset;
    
	
	void Start () {
        offset = ball.transform.position - transform.position;
        BallController.gameOver = false;
	}
	
	
	void Update () {
		if(!BallController.gameOver)
        {
            Follow();
        }
	}

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
