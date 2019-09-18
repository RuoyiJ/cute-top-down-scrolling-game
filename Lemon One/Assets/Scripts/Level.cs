﻿using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour
{
    public static int TargetDistance { get; private set; }
    public static float SpeedMultiplier { get; private set; }
    private List<int> columnIndexs;

    [SerializeField]
    ObjectManager objManager;
    [SerializeField]
    float spawnTime = 0.5f;
    float timer = 0;

    private void Start()
    {
        TargetDistance = 100;
        SpeedMultiplier = 1f;
        columnIndexs = new List<int>();

    }
    private void Update()
    {
        if (AutoScrollBackground.DistanceLeft > 0 && (timer += Time.deltaTime) > spawnTime &&
            (AutoScrollBackground.IsScrolling || PlayerMovement.IsAutoMove))
        {
            columnIndexs.Clear();
            SpawnPrawns();
            //SpawnRabbish();
            timer = 0;
        }
    }
    void SpawnPrawns()
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
                Spawning.RandomSpawn("Prawn", columnIndex);
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
                Spawning.RandomSpawn("Rabbish", columnIndex);
                columnIndexs.Add(columnIndex);
            }
        }

    }
}