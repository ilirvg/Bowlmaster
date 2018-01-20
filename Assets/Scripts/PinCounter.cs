using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {
    public Text standingDisplay;
    public bool ballLeftBox = false;

    private GameManager gameManager;
    private int lastSetteledCount = 10;
    private float lastChangedTime;
    private int lastStandingCount = -1;

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update () {
        standingDisplay.text = CountStanding().ToString();
        if (ballLeftBox) {
            standingDisplay.color = Color.red;
            CheckStanding();
        }
    }
    public void Reset() {
        lastSetteledCount = 10;
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.name == "Ball") {
            ballLeftBox = true;
        }
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
        int standing = CountStanding();
        int pinFall = lastSetteledCount - standing;
        lastSetteledCount = standing;

        gameManager.Bowl(pinFall);

        lastStandingCount = -1;
        ballLeftBox = false;
        standingDisplay.color = Color.green;
    }
    
}
