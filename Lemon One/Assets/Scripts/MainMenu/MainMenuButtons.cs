using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

	public void Play()
    {
        UIObjects.Main.gameObject.SetActive(false);
        UIObjects.LevelSelection.gameObject.SetActive(true);
    }

    public void OpenRecords()
    {
        UIObjects.Main.gameObject.SetActive(false);
        UIObjects.Records.gameObject.SetActive(true);
    }
    public void Back()
    {
        transform.parent.gameObject.SetActive(false);
        UIObjects.Main.gameObject.SetActive(true);
    }

    public void DeleteData()
    {
        SaveDataManager.DeleteData();
        SaveDataManager.CreatePlayerData();
        SaveDataManager.LoadPlayerData();
    }

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevelThree()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadLevelInfinity()
    {
        SceneManager.LoadScene(4);
    }
}
