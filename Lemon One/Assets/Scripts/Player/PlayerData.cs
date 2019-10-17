using System;
using UnityEngine;

[Serializable]
public class PlayerData {

	public int[] BestRecord { get; private set; }
    public int TotalPrawnsCollected { get; private set; }
    public int TotalPlayingMins { get; private set; }
    public int LevelUnlocked { get; private set; }

    public PlayerData()
    {
        BestRecord = new int[4];
        LevelUnlocked = 1;
    }

    public PlayerData(int[] bestRecord, int totalPrawns, int playingMins, int levelUnlocked)
    {
        BestRecord = bestRecord;
        TotalPrawnsCollected = totalPrawns;
        TotalPlayingMins = playingMins;
        LevelUnlocked = levelUnlocked;
    }
}
