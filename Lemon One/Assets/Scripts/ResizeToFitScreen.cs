using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeToFitScreen : MonoBehaviour {
    SpriteRenderer bg;
    [SerializeField, Range(0,1f)]
    float screenRatio;

	// Use this for initialization
	void Awake () {
        bg = GetComponent<SpriteRenderer>();
        Resize();
    }

    private void Resize()
    {
        float screenHeight = Camera.main.orthographicSize * 2f;
        float screenWidth = screenHeight / Screen.height * Screen.width;
        float scaleFactor = screenWidth / bg.sprite.bounds.size.x * screenRatio;
        transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);

    }
}
