using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    public GameObject pinSet;

    private PinCounter pinCounter;
    private Pin pin;
    private Animator animator;
    //private ActionMaster actionMaster = new ActionMaster();

    void Start() {
        pin = FindObjectOfType<Pin>();
        pinCounter = FindObjectOfType<PinCounter>();
        animator = GetComponent<Animator>();
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

    public void PerformAction(ActionMaster.Action action) {
        if (action == ActionMaster.Action.Tidy) {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn) {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.Reset) {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame) {
            throw new UnityException("yet to define how to heandle endGame");
        }
    }
}
