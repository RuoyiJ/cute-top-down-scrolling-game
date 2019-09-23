using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        if (SaveDataManager.IsSaveDataExists())
            SaveDataManager.LoadPlayerData();
        else
            SaveDataManager.CreatePlayerData();

        Debug.Log(PlayerDataRef.BestRecord[0]);
	}
	
	
}
