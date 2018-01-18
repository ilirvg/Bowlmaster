using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBox : MonoBehaviour {
    private PinSetter pinSetter;

    private void Start() {
        pinSetter = FindObjectOfType<PinSetter>();
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Ball") {
            pinSetter.ballLeftBox = true;
        }
    }
}
