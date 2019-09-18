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
            Time.timeScale = 0;
            AutoScrollBackground.IsScrolling = false;
        }
        else
        {
            Time.timeScale = 1;
            AutoScrollBackground.IsScrolling = true;
        }

        Debug.Log(Time.timeScale);
    }
}
