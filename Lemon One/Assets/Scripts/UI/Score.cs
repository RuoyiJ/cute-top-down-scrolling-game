using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

	void OnEnable()
    {
        Text score = GetComponent<Text>();
        score.text = ObjectManager.Score.text;
        CompareScore(int.Parse(score.text));
    }

    void CompareScore(int currentScore)
    {
        int levelIndex = SceneManager.GetActiveScene().buildIndex;
        int bestScore = PlayerDataRef.BestRecord[levelIndex - 1];
        if (currentScore > bestScore)
        {
            PlayerDataRef.BestRecord[levelIndex - 1] = currentScore;
        }
        if(ObjectManager.Player.currentLives > 0 && levelIndex==PlayerDataRef.LevelUnlocked)
        {
            PlayerDataRef.LevelUnlocked++;
        }
        SaveDataManager.SavePlayerData(PlayerDataRef.BestRecord, PlayerDataRef.TotalPrawnsCollected + PlayerDataRef.currentPrawns,
                PlayerDataRef.TotalPlayingMins, PlayerDataRef.LevelUnlocked);
    }
}
