using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    SpriteRenderer bg;
    float screenHeight;
    float scaleFactor;
    [SerializeField, Range(0, 0.5f)]
    float fixStartPointOnScreen;
    [SerializeField, Range(1, 10f)]
    float initSpeed;

    public static bool IsAutoMove { get; private set; }
    public static bool IsAutoMoveFinish { get; private set; }
    // Use this for initialization
    void Start()
    {
        bg = GetComponent<SpriteRenderer>();
        //put img to bottom
        scaleFactor = transform.localScale.x;
        screenHeight = Camera.main.orthographicSize * 2f;
        float y = bg.sprite.bounds.size.y * scaleFactor - screenHeight;
        y /= 2;
        transform.position = Vector3.zero + new Vector3(0, y, 0);
        IsAutoMove = false;
        IsAutoMoveFinish = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height * fixStartPointOnScreen, 10)).y)
        {
            IsAutoMove = true;
        }
        if (IsAutoMove)
        {
            transform.position += new Vector3(0, initSpeed * Time.deltaTime, 0);
        }
        if (transform.position.y >= Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height * fixStartPointOnScreen, 10)).y)
        {
            IsAutoMove = false;
            IsAutoMoveFinish = true;
            GetComponent<PlayerControl>().IsMoving = true;
        }

    }
   
}
