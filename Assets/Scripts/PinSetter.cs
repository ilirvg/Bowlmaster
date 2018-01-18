using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    public Text standingDisplay;
    public GameObject pinSet;
    public bool ballLeftBox = false;

    private Pin pin;
    private Ball ball;
    private Animator animator;
    private ActionMaster actionMaster = new ActionMaster(); // nede to be here to have only one value
    private float lastChangedTime;
    private int lastSetteledCount = 10;
    private int lastStandingCount = -1;

    void Start() {
        ball = FindObjectOfType<Ball>();
        pin = FindObjectOfType<Pin>();
        animator = GetComponent<Animator>();
    }
    void Update() {
        standingDisplay.text = CountStanding().ToString();
        if (ballLeftBox) {
            standingDisplay.color = Color.red;
            CheckStanding();
        }
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
        ActionMaster.Action action = actionMaster.Bowl(pinFall);
        Debug.Log("Pinfall " + pinFall + action);

        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        }
        else if(action == ActionMaster.Action.EndTurn){
            animator.SetTrigger("resetTrigger");
            lastSetteledCount = 10;
        }
        else if (action == ActionMaster.Action.Reset) {
            animator.SetTrigger("resetTrigger");
            lastSetteledCount = 10;
        }
        else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("yet to define how to heandle endGame");
        }
        ball.Reset();
        lastStandingCount = -1;
        ballLeftBox = false;
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
    public void RaisePins() {
        foreach(Pin pin in FindObjectsOfType<Pin>()) { 
            pin.Raise();
        }
    }
    public void RenewPins() {
        Instantiate(pinSet, new Vector3(0, pin.distanceToRaise, 1829), Quaternion.identity);
    }
    public void LowerPins() {
        foreach (Pin pin in FindObjectsOfType<Pin>()) {
            pin.Lower();
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.GetComponent<Pin>()) {
            Destroy(other.gameObject);
        }
    }
}
