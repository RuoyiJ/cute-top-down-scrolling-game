﻿using UnityEngine;

public class Spawning {
    
    
    // Random Spawn object in column without overlapping,return x index
    public static void SpawnObject(string tag, int columnIndex)
    {
        GameObject obj = ObjectPool.sharedInstance.GetPooledObject(tag);
        if (obj != null)
        {
            float x = Grid.XPosition(columnIndex);
            float y = Screen.height + 100;
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
            pos.z = 0;
            obj.transform.position = pos;
            obj.SetActive(true);
        }
    }
}
public class Grid
{
    public static int XPosition(int columnIndex)
    {
        int columnWidth = Screen.width / 5;
        switch (columnIndex)
        {
            case -1:
                return -columnWidth;
            case 0:
                return columnWidth / 2;
            case 1:
                return columnWidth + columnWidth / 2;
            case 2:
                return columnWidth * 2 + columnWidth / 2;
            case 3:
                return columnWidth * 3 + columnWidth / 2;
            case 4:
                return columnWidth * 4 + columnWidth / 2;
            case 5:
                return Screen.width + columnWidth;
            default:
                Debug.Log("columnIndex out of range");
                break;
        }
        return -1;
    }
}
