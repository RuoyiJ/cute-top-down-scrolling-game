using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishDecoration : MonoBehaviour {
    SpriteRenderer fishSprite;
	void Start()
    {
        fishSprite = GetComponent<SpriteRenderer>();
    }
}
