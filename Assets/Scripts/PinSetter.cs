using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PinSetter : MonoBehaviour {

    public Text standingDisplay;

	void Start () {
        
    }
	
	void Update () {
        standingDisplay.text = CountStanding().ToString();
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
}
