using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
    public float standingThreshold = 3f;
    public float distanceToRaise = 40f;

    public bool IsStanding() {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if (tiltInX < standingThreshold && tiltInZ < standingThreshold) {
            return true;
        }
        else {
            return false;
        }
    }

    public void Raise() {
        if (IsStanding()) {
            GetComponent<Rigidbody>().useGravity = false;
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
            transform.rotation = Quaternion.Euler(270f,0,0);
        }
    }

    public void Lower() {
        transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
        GetComponent<Rigidbody>().useGravity = false;
        transform.rotation = Quaternion.Euler(270f, 0, 0);
    }

}
