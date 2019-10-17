using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public static int TargetDistance { get; private set; }
    public static bool IsEnd { get; private set; }
    public static float SpeedMultiplier { get; set; }
    //private List<int> columnIndexs;

    float distanceCounter = 0;
    [SerializeField]
    float spawnDistance = 0.8f;

    public const char prawnObj = '1';
    public const char rubbishObj = '2';
    public const char sharkObj = '3';
    List<string> levelData;

    TextAsset textFile;

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
        if (AutoScrollBackground.DistanceLeft > 0 && (distanceCounter += AutoScrollBackground.ScrollSpeed * Time.deltaTime) > spawnDistance &&
            (PlayerMovement.IsAutoMoveFinish))
        {
            //columnIndexs.Clear();
            //SpawnPrawns();
            //SpawnRabbish();
            if (levelData.Count > 0)
            {
                GenerateRowFromList();
                distanceCounter = 0;
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
        textFile = Resources.Load<TextAsset>("LevelData/level" + SceneManager.GetActiveScene().buildIndex );
        levelData = FileReader.TextAssetToList(textFile);
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
            Pause.PauseGame();
            ObjectManager.GameOverPanel.gameObject.SetActive(true);
        }
    }
    private void Win()
    {
        if(levelData.Count<=0 && ObjectManager.Player.currentLives > 0)
        {
            IsEnd = true;
            distanceCounter += AutoScrollBackground.ScrollSpeed * Time.deltaTime;
            if (distanceCounter > 3f)
            {
                ObjectManager.CompletionPanel.gameObject.SetActive(true);
                Pause.PauseGame();
            }
        }
    }
    #endregion
}
