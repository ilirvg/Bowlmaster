using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class BallDragLounch : MonoBehaviour {
    private Ball ball;
    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;
    
	void Start () {
        ball = GetComponent<Ball>();
	}

    public void DragStart() {
        if (ball.lounched == false) {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }
    }

    public void DragEnd() {
        if (ball.lounched == false) {
            dragEnd = Input.mousePosition;
            endTime = Time.time;
            float dragDuration = endTime - startTime;
            float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;
            Vector3 lounchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
            ball.Lounch(lounchVelocity);
        }
    }

    public void MoveStart(float xNudge) {
        if (!ball.lounched) {
            transform.Translate (new Vector3(xNudge, 0, 0));
        }
    }
}
