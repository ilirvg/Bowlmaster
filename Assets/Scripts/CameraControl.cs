using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Ball ball;

    Vector3 offset;
	void Start () {
        offset = transform.position - ball.transform.position;
    }
	
	
	void Update () {
        if(transform.position.z <= 1829) { 
            transform.position = ball.transform.position + offset;
        }
    }
}
