using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PinSetter : MonoBehaviour {

    public int lastStandingCount = -1;
    public Text standingDisplay;
    public float distanceToRaise = 40f;

    private Ball ball;
    private float lastChangedTime;
    private bool ballEnteredBox = false;

    void Start() {
        ball = FindObjectOfType<Ball>();
    }

    void Update() {
        standingDisplay.text = CountStanding().ToString();
        if (ballEnteredBox) {
            CheckStanding();
        }
    }
    public void RaisePins() {
        Debug.Log("Raise Pins");
        foreach (Pin pin in FindObjectsOfType<Pin>()) {
            if (pin.IsStanding()) {
                pin.transform.Translate(new Vector3(0, distanceToRaise, 0));
            }
        }
    }
    public void RenewPins() {
        Debug.Log("Renew Pins");
    }
    public void LowerPins() {
        Debug.Log("Lowering Pins");
    }
    private void CheckStanding() {
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount) {
            lastChangedTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }
        float settleTime = 3f;
        if ((Time.time - lastChangedTime) > settleTime) {
            PinsHaveSettled();
        }
    }

    private void PinsHaveSettled() {
        ball.Reset();
        lastChangedTime = -1;
        ballEnteredBox = false;
        standingDisplay.color = Color.green;
    }

    private int CountStanding() {
        int standing = 0;
        foreach (Pin pin in FindObjectsOfType<Pin>()) {
            if (pin.IsStanding()) {
                standing++;
            }
        }
        return standing;
    }

    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<Pin>()) {
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Ball>()) {
            ballEnteredBox = true;
            standingDisplay.color = Color.red;
        }
    }
}
