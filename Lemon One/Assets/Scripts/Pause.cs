using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    bool paused = false;
    
	public void ChangeGameStatus()
    {
        paused = !paused;
        if (paused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }

        Debug.Log(Time.timeScale);
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
        AutoScrollBackground.IsScrolling = false;
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
        AutoScrollBackground.IsScrolling = true;
    }
}
