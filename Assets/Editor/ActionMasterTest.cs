using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest {
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;
    private ActionMaster.Action endGame = ActionMaster.Action.EndGame;
    private List<int> pinFalls;

    [SetUp]
    public void Setup() {
        pinFalls = new List<int>();
    }
    [Test]
    public void T00PassingTest() {
        Assert.AreEqual(1, 1);
    }
    [Test]
    public void T01OneStrikeReturnsEndTurn() {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }
    [Test]
    public void T02Bowl8Return() {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }
    [Test]
    public void T03Bowl28ReturnsEndTurn() {
        pinFalls.Add(2);
        pinFalls.Add(8);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }
    [Test]
    public void T04TenthFrameFirstThroughReturnReset() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T05TenthFrameFirstThroughReturnTidy() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T06TenthFrameSecondThroughReturnReset() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 7 };
        Assert.AreEqual(reset, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T07TenthFrameSecondThroughReturnEndGame() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 4 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T08TenthFrameThirdThroughReturnEndGame() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 5, 10 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T09YoutubeRollsArray() {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T10TidyFail() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0 };
        Assert.AreEqual(tidy, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T11NathanKnock10PinsOnSecondBowl() {
        int[] rolls = { 0, 10, 5, 1 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T12Dondi10thFrame() {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };
        Assert.AreEqual(endGame, ActionMaster.NextAction(rolls.ToList()));
    }
    [Test]
    public void T13EndTurnAfter01() {
        int[] rolls = { 0, 1 };
        Assert.AreEqual(endTurn, ActionMaster.NextAction(rolls.ToList()));
    }
}