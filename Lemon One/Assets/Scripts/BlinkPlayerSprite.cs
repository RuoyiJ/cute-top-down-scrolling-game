using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkPlayerSprite : MonoBehaviour {

    SpriteRenderer m_spriteRender;
    IEnumerator coroutine;
	// Use this for initialization
	void Start () {
        m_spriteRender = GetComponent<SpriteRenderer>();
        //CollisionEvents.OnObstacleCollision += StartBlinking;
        coroutine = Blink();
	}

    void StartBlinking()
    {
        StartCoroutine(coroutine);
    }
	
    IEnumerator Blink()
    {
        for (int i = 0; i < 2;i++)
        {
            m_spriteRender.enabled = false;
            yield return new WaitForSecondsRealtime(0.2f);
            m_spriteRender.enabled = true;
            yield return new WaitForSecondsRealtime(0.2f);

        }
    }
}
