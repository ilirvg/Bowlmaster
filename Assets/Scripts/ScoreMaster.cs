using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class ScoreMaster {

    public static List<int> ScoreCumulative(List<int> rolls) {
        List<int> comulativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int framScore in ScoreFrames(rolls)) {
            runningTotal += framScore;
            comulativeScores.Add(runningTotal);
        }


        return comulativeScores;
    }

    public static List<int> ScoreFrames(List<int> rolls) {

        List<int> frameList = new List<int>();

        bool strike = false;
        bool lastFrameStrike = false;
        int inMinde = 0;

        for (int i = 0; i < rolls.Count - 1; i++) {
            for (int j = i + 1; j <= i + 1; j++) {

                if (inMinde != 0) {                                     //the amount that we keep in mind from the spare/strike
                    inMinde += rolls[j];
                    frameList.Add(inMinde);
                    inMinde = 0;
                }

                if (strike && !lastFrameStrike) {                       //for strike we add a 0 in the list after i 
                    rolls.Insert((i), 0);
                    strike = false;
                }
                // smiply add the rolls in list
                else if ((rolls[i] + rolls[j]) < 10 && j % 2 == 1) { frameList.Add(rolls[i] + rolls[j]); }

                else if ((rolls[i] + rolls[j]) >= 10 && j % 2 == 1) {  // cases when we have strike or spare
                    inMinde = rolls[i] + rolls[j];
                    if ((rolls[i] == 10)) {
                        strike = true;
                        if (i == 18) {                                  // last frame with strike
                            lastFrameStrike = true;
                        }
                    }
                }
            }
        }
        return frameList;
    }
}
