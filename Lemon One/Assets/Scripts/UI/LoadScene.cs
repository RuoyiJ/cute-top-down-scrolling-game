using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void ReloadLevel()
    {
        Pause.ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNext()
    {
        Pause.ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
