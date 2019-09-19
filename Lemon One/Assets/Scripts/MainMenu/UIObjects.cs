using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObjects : MonoBehaviour {

    [SerializeField]
    private RectTransform main, levelSelection, records;

    public static RectTransform Main { get; set; }
    public static RectTransform LevelSelection { get; set; }
    public static RectTransform Records { get; set; }
    void Awake()
    {
        Main = main;
        LevelSelection = levelSelection;
        Records = records;
    }
}
