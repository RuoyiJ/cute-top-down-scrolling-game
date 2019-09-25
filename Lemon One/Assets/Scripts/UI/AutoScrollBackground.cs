using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoScrollBackground : MonoBehaviour {
    public float ScrollSpeed;
    float distanceScrolled;
    public static bool IsScrolling { get; set; }
    bool firstpass;
    float screenHeight;
    float scaleFactor;
    Vector3 move;

    SpriteRenderer bg;
    [SerializeField]
    SpriteRenderer top, scroll1, scroll2;

    public static int DistanceLeft { get; private set; }
    public bool IsTargetHit { get; private set; }

	// Use this for initialization
	void Start () {
        bg = GetComponent<SpriteRenderer>();

        //put bg to bottom
        scaleFactor = transform.localScale.x;
        screenHeight = Camera.main.orthographicSize * 2f;
        float y = bg.sprite.bounds.size.y * scaleFactor - screenHeight;
        y /= 2;
        transform.position = Vector3.zero + new Vector3(0, y, 0);

        distanceScrolled = 0;
        IsScrolling = false;
        IsTargetHit = false;
        firstpass = false;
        move = new Vector3(0, ScrollSpeed * Level.SpeedMultiplier, 0);
        SetDistanceLeft();
    }
	
	// Update is called once per frame
	void Update () {

        ScrollingBackground();
	}

    void ScrollingBackground()
    {
        if (Input.GetMouseButtonDown(0))
            IsScrolling = true;
        if (IsScrolling && !IsImgPassed(bg) && PlayerMovement.IsAutoMoveFinish)
        {
            transform.position -= move * Time.deltaTime;
            distanceScrolled += ScrollSpeed * Level.SpeedMultiplier * Time.deltaTime;
        }
        if (IsScrolling && IsImgPassed(bg) && !firstpass && PlayerMovement.IsAutoMoveFinish && !IsEndReach())
        {
            scroll1.transform.position -= move * Time.deltaTime;
            scroll2.transform.position = scroll1.transform.position + new Vector3(0, scroll1.sprite.bounds.size.y, 0) * scaleFactor;
            top.transform.position = scroll2.transform.position + new Vector3(0, scroll1.sprite.bounds.size.y, 0) * scaleFactor;
            distanceScrolled += ScrollSpeed * Level.SpeedMultiplier * Time.deltaTime;
        }
        else if (IsScrolling && IsImgPassed(bg) && firstpass && PlayerMovement.IsAutoMoveFinish && !IsEndReach())
        {
            scroll2.transform.position -= move * Time.deltaTime;
            scroll1.transform.position = scroll2.transform.position + new Vector3(0, scroll1.sprite.bounds.size.y, 0) * scaleFactor;
            top.transform.position = scroll1.transform.position + new Vector3(0, scroll1.sprite.bounds.size.y, 0) * scaleFactor;
            distanceScrolled += ScrollSpeed * Level.SpeedMultiplier * Time.deltaTime;
        }
        if (IsScrolling && IsEndReach() && top.transform.position.y + top.sprite.bounds.size.y / 2 * scaleFactor
            > Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y)
        {
            transform.position -= move * Time.deltaTime;
            distanceScrolled += ScrollSpeed * Level.SpeedMultiplier * Time.deltaTime;
        }
        if (top.transform.position.y + top.sprite.bounds.size.y / 2 * scaleFactor - ScrollSpeed * Level.SpeedMultiplier * Time.deltaTime
            <= Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y)
        {
            IsScrolling = false;
        }
        if (IsImgPassed(scroll1))
        {
            firstpass = true;
        }
        else if (IsImgPassed(scroll2))
        {
            firstpass = false;
        }
        SetDistanceLeft();
    }

    bool IsImgPassed(SpriteRenderer img)
    {
        float ytop = img.transform.position.y + img.sprite.bounds.size.y * scaleFactor / 2;
        if (ytop < -screenHeight / 2)
            return true;
        return false;
    }

    bool IsEndReach()
    {
        //if (Level.TargetDistance - distanceScrolled < scroll1.sprite.bounds.size.y * scaleFactor)
        //{
        //    return true;
        //}
        if (Level.IsEnd)
            return true;
        return false;
    }
    void SetDistanceLeft()
    {
        DistanceLeft = Level.TargetDistance - (int)distanceScrolled;
    }
}
