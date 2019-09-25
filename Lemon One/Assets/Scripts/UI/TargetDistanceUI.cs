using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetDistanceUI : MonoBehaviour {
    Text distanceText;

	// Use this for initialization
	void Start () {
        distanceText = GetComponent<Text>();
        UpdateUI();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateUI();
	}

    void UpdateUI()
    {
        int distanceLeft = Mathf.Max(0, AutoScrollBackground.DistanceLeft);
        distanceText.text = distanceLeft.ToString() + "m";
    }
}
