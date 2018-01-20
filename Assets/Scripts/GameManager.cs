using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private List<int> bowls = new List<int>();
    private Ball ball;
    private PinSetter pinSetter;

    void Start () {
        ball = FindObjectOfType<Ball>();
        pinSetter = FindObjectOfType<PinSetter>();
    }
    public void Bowl(int pinFall) {
        bowls.Add(pinFall);

        ActionMaster.Action nextAction = ActionMaster.NextAction(bowls);
        pinSetter.PerformAction(nextAction);
        ball.Reset();
    }
}
