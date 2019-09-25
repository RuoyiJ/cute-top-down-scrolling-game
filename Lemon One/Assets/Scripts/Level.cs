using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static int TargetDistance { get; private set; }
    public static bool IsEnd { get; private set; }
    public static float SpeedMultiplier { get; set; }
    //private List<int> columnIndexs;

    [SerializeField]
    float spawnTime = 0.1f;
    float timer = 0;

    public const char prawnObj = '1';
    public const char rubbishObj = '2';
    public const char sharkObj = '3';
    List<string> levelData;

    private void Awake()
    {
        TargetDistance = 100;
        SpeedMultiplier = 1f;
    }
    private void Start()
    {
        Pause.ResumeGame();
        ObjectManager.GameOverPanel.gameObject.SetActive(false);
        
        //columnIndexs = new List<int>();
        LoadCollidables();
        IsEnd = false;

    }
    private void Update()
    {
        if (AutoScrollBackground.DistanceLeft > 0 && (timer += Time.deltaTime) > spawnTime &&
            (PlayerMovement.IsAutoMoveFinish))
        {
            //columnIndexs.Clear();
            //SpawnPrawns();
            //SpawnRabbish();
            if (levelData.Count > 0)
            {
                GenerateRowFromList();
                timer = 0;
            }
        }
        GameOver();
        Win();
    }
    #region Random Spawning
    /*void SpawnPrawns()
    {
        int r = Random.Range(1, 3);
        for (int i = 0; i < r; i++)
        {
            int columnIndex = Random.Range(0, 5);
            int count = 0;
            while (columnIndexs.Contains(columnIndex))
            {
                count++;
                columnIndex = Random.Range(0, 5);
                if (count > 3)
                    break;
            }
            if (!columnIndexs.Contains(columnIndex))
            {
                Spawning.SpawnObject("Prawn", columnIndex);
                columnIndexs.Add(columnIndex);
            }
        }
    }

    void SpawnRabbish()
    {

        int r = Random.Range(0, 2);
        for (int i = 0; i < r; i++)
        {
            int columnIndex = Random.Range(0, 5);
            int count = 0;
            while (columnIndexs.Contains(columnIndex))
            {
                count++;
                columnIndex = Random.Range(0, 5);
                if (count > 3)
                    break;
            }
            if (!columnIndexs.Contains(columnIndex))
            {
                Spawning.SpawnObject("Rabbish", columnIndex);
                columnIndexs.Add(columnIndex);
            }
        }

    }*/
    #endregion

    #region LoadLevelFromTxtFile
    private void LoadCollidables()
    {
        string path = "Assets/Resources/LevelData/level" + SceneManager.GetActiveScene().buildIndex + ".txt";
        //string path = "Assets/Resources/LevelData/level1.txt";
        levelData = FileReader.ReadTextFile(path);
        //Debug.Log(levelData == null);
    }

    private void GenerateRowFromList()
    {
        string bottomRow = levelData[levelData.Count - 1];
        //Debug.Log(bottomRow);
        for (int i = 0; i < bottomRow.Length; i++)
        {
            switch(bottomRow[i])
            {
                case prawnObj:
                    Spawning.SpawnObject("Prawn", i-1);
                    Debug.Log(i);
                    break;
                case rubbishObj:
                    Spawning.SpawnObject("Rabbish", i-1);
                    break;
                case sharkObj:
                    Spawning.SpawnObject("Shark", i-1);
                    break;
                default:
                    break;
            }
        }
        levelData.RemoveAt(levelData.Count - 1);
    }

    private void GameOver()
    {
        if (ObjectManager.Player.currentLives == 0)
        {
            ObjectManager.GameOverPanel.gameObject.SetActive(true);
            Pause.PauseGame();
        }
    }
    private void Win()
    {
        if(levelData.Count<=0 && ObjectManager.Player.currentLives > 0)
        {
            IsEnd = true;
            timer += Time.deltaTime;
            if (timer > 3f)
            {
                ObjectManager.CompletionPanel.gameObject.SetActive(true);
                Pause.PauseGame();
            }
        }
    }
    #endregion
}
