using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreMaster {

    public static List<int> ScoreCumulative(List<int> rolls) {
        List<int> comulativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int framScore in ScoreFrames(rolls)) {
            runningTotal += framScore;
            comulativeScores.Add(runningTotal);
        }


        return comulativeScores;
    }

    public static List<int> ScoreFrames (List<int> rolls) {
        List<int> frameList = new List<int>();
        bool strike = false;
        bool lastFrameStrike = false;
        int inMinde = 0;
        for (int i = 0; i < rolls.Count - 1; i++) {
            for (int j = i + 1; j <= i+1; j++) {
                if (inMinde != 0) {
                    inMinde += rolls[j];
                    frameList.Add(inMinde);
                    inMinde = 0;
                }
                if (strike && !lastFrameStrike) {
                    rolls.Insert((i), 0);
                    strike = false;
                }
                else if ((rolls[i] + rolls[j]) < 10 && j % 2 == 1) { frameList.Add(rolls[i] + rolls[j]); }
                else if ((rolls[i] + rolls[j]) >= 10 && j % 2 == 1) {
                    inMinde = rolls[i] + rolls[j];
                    if ((rolls[i] == 10)) {
                        strike = true;
                        if (i == 18) {
                            lastFrameStrike = true;
                        }
                    }
                }
            }
        }
        return frameList;
    }
}
