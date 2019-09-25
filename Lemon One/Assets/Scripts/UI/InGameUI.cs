using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour {

    public static Text lives, prawns, score;

    private void Start()
    {

        lives = ObjectManager.Lives;
        prawns = ObjectManager.Prawns;
        score = ObjectManager.Score;

        lives.text = ObjectManager.Player.currentLives.ToString();
        prawns.text = ObjectManager.Player.currentPrawns.ToString();
        score.text = ObjectManager.Player.currentScore.ToString();

    }


    public static void UpdateUI(IPlayerController player)
    {
        if (player != null)
        {
            lives.text = player.currentLives.ToString();
            prawns.text = player.currentPrawns.ToString();
            score.text = player.currentScore.ToString();
        }
    }

}
