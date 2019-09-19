using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour
{
    public static int TargetDistance { get; private set; }
    public static float SpeedMultiplier { get; private set; }
    //private List<int> columnIndexs;

    [SerializeField]
    ObjectManager objManager;
    [SerializeField]
    float spawnTime = 0.1f;
    float timer = 0;

    public const char prawnObj = '1';
    public const char rubbishObj = '2';
    public const char sharkObj = '3';
    List<string> levelData;

    private void Start()
    {
        TargetDistance = 100;
        SpeedMultiplier = 1.2f;
        //columnIndexs = new List<int>();
        LoadCollidables();


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
                timer = 0;
                GenerateRowFromList();
            }
        }
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
        levelData = FileReader.ReadTextFile("Assets/Resources/LevelData/test.txt");
        Debug.Log(levelData == null);
    }

    private void GenerateRowFromList()
    {
        string bottomRow = levelData[levelData.Count - 1];
        Debug.Log(bottomRow);
        for (int i = 0; i < bottomRow.Length; i++)
        {
            switch(bottomRow[i])
            {
                case prawnObj:
                    Spawning.SpawnObject("Prawn", i);
                    Debug.Log(i);
                    break;
                case rubbishObj:
                    Spawning.SpawnObject("Rabbish", i);
                    break;
                case sharkObj:
                    Spawning.SpawnObject("Shark", i);
                    break;
                default:
                    break;
            }
        }
        levelData.RemoveAt(levelData.Count - 1);
    }

    #endregion
}
