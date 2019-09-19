using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : Rubbish {

    Vector3 screenPos;
    [SerializeField]
    float speed;
    [SerializeField]
    float startAttackTime;
    float waitTime = 0f;
    float timer = 0;
    bool flip;
    bool pause = false;
    bool backwards = false;
	public override CollidableType Collidable
    {
        get { return CollidableType.Shark; }
    }

    protected override void OnEnable()
    {
        obsCollider = GetComponent<BoxCollider2D>();
        obsCollider.enabled = true;
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        timer = 0;
        if (screenPos.x < 0)
        {
            flip = true;
            GetComponent<SpriteRenderer>().flipX = true;
            //Debug.Log("fliped");
        }
        else if (screenPos.x > Screen.width)
        {
            flip = false;
            GetComponent<SpriteRenderer>().flipX = false;
            //Debug.Log("not fliped");
        }
        else
            Debug.Log("Shark in wrong position");
    }

    protected override void Update()
    {
        base.Update();
        Movement();
        timer += Time.deltaTime;
    }

    //TO DO: USE FSM INSTEAD OF THIS BUGGY MOVEMENT
    private void Movement()
    {
        if (timer >= startAttackTime)
        {
            Vector3 move = new Vector3(speed * Time.deltaTime, 0);
            float xPosOnScreen = Camera.main.WorldToScreenPoint(transform.position).x;
            if ((flip && xPosOnScreen >= Screen.width / 3) ||
                (!flip && xPosOnScreen < Screen.width * 2 / 3))
            {
                backwards = true;
                pause = true;
                waitTime += Time.deltaTime;
            }
            else if((flip && xPosOnScreen < -Screen.width / 3) ||
                (!flip && xPosOnScreen >= Screen.width * 4 / 3))
            {
                backwards = false;
                pause = true;
                waitTime += Time.deltaTime;
            }
            if(waitTime > 1f)
            {
                pause = false;
                waitTime = 0;
            }
            if ((flip && !backwards) ||(!flip && backwards) && !pause)
            {
                transform.position += move;
            }
            else if ((flip && backwards) || (!flip && !backwards) && !pause)
            {
                transform.position -= move;
            }
        }
    }
 
}
