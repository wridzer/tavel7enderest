using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScoreTypes{
    CORRECT = 0,
    WRONG = 1
}

public static class ScoreKeeper
{
    private static int score;
    private static Dictionary<CallObject, ScoreTypes> scoreDict = new Dictionary<CallObject, ScoreTypes>();

    public static void AddScore(CallObject call)
    {
        if (!scoreDict.ContainsKey(call))
        {
            if (call.IsCriminal)
            {
                scoreDict.Add(call, ScoreTypes.CORRECT);
            }
            else
            {
                scoreDict.Add(call, ScoreTypes.WRONG);
            }
        }
    }

    private static void EndGame(List<CallObject> callList)
    {
        foreach(CallObject call in callList)
        {
            if (!scoreDict.ContainsKey(call))
            {
                if (call.IsCriminal)
                {
                    scoreDict.Add(call, ScoreTypes.WRONG);
                }
                else
                {
                    scoreDict.Add(call, ScoreTypes.CORRECT);
                }
            }
        }

        foreach(KeyValuePair<CallObject, ScoreTypes> pair in scoreDict)
        {
            //good no report
            if(pair.Value == ScoreTypes.CORRECT && !pair.Key.IsCriminal)
            {
                score++;
            }
            //bad no report
            if (pair.Value == ScoreTypes.WRONG && pair.Key.IsCriminal)
            {
                score--;
            }
            //good report
            if (pair.Value == ScoreTypes.CORRECT && pair.Key.IsCriminal)
            {
                score += 2;
            }
            //bad report
            if (pair.Value == ScoreTypes.WRONG && !pair.Key.IsCriminal)
            {
                score -= 2;
            }
        }
    }
}