using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataRef
{

    public static int[] BestRecord { get; set; }
    public static int TotalPrawnsCollected { get; set; }
    public static int TotalPlayingMins { get; set; }
    public static int LevelUnlocked { get; set; }

    public static int currentScore { get; set; }
    public static int currentPrawns { get; set; }

    public static void Initialise(int[] bestRecord, int totalPrawns, int playingMins, int levelUnlocked)
    {
        BestRecord = bestRecord;
        TotalPrawnsCollected = totalPrawns;
        TotalPlayingMins = playingMins;
        LevelUnlocked = levelUnlocked;
    }
}
