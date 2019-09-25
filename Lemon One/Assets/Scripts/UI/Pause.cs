using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {
    bool paused = false;
    Image m_sprite;
    public Sprite pause, resume;
    void Start()
    {
        m_sprite = GetComponent<Image>();
        m_sprite.sprite = pause;
    }
	public void ChangeGameStatus()
    {
        paused = !paused;
        if (paused)
        {
            PauseGame();
            m_sprite.sprite = resume;
        }
        else
        {
            ResumeGame();
            m_sprite.sprite = pause;
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
