using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour {

    [SerializeField]
    ObjectManager objManager;
    public static Text lives, prawns, score;

    private void Start()
    {
        if (objManager!= null)
        {
            lives = objManager.lives;
            prawns = objManager.prawns;
            score = objManager.score;
        }
        else
            Debug.Log("ObjectManager not found");
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
