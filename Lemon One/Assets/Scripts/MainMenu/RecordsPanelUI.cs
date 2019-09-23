using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsPanelUI : MonoBehaviour {

    [SerializeField]
    Text lvl1Score, lvl2Score, lvl3Score, lvlInfScore;
    [SerializeField]
    Text totalPrawns;
    [SerializeField]
    Text playTime;

	// Use this for initialization
	void Start () {
        lvl1Score.text = PlayerDataRef.BestRecord[0].ToString();
        lvl2Score.text = PlayerDataRef.BestRecord[1].ToString();
        lvl3Score.text = PlayerDataRef.BestRecord[2].ToString();
        lvlInfScore.text = PlayerDataRef.BestRecord[3].ToString();
        totalPrawns.text = PlayerDataRef.TotalPrawnsCollected.ToString();
        int h = PlayerDataRef.TotalPlayingMins / 60;
        int m = PlayerDataRef.TotalPlayingMins % 60;
        playTime.text = h +":"+m;

	}
	
	
}
