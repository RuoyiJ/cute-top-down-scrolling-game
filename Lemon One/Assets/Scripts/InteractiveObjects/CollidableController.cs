using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollidableController : MonoBehaviour, ICollidable
{
    protected bool isOffScreen = false;
    public Vector2 widthTreshold;
    public Vector2 heightTreshold;
    public abstract CollidableType Collidable { get; }

    public IPlayerController Player { get; private set; }

    public float ScrollSpeed { get; private set; }

    protected virtual void Awake()
    {
        Player = null;
    }

    protected virtual void Update()
    {
        Scrolling();
        OffScreenDestruction();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(enabled && Player == null &&
            (Player = other.GetComponent<IPlayerController>())!=null &&
            !Player.enabled)
        {
            Player = null;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if(Player != null && Player == other.GetComponent<IPlayerController>())
        {
            Player = null;
        }
    }
    public abstract void CollisionResolve();

    public virtual void Scrolling()
    {
        ScrollSpeed = 6f * Level.SpeedMultiplier;
        if (PlayerMovement.IsAutoMoveFinish)
            transform.position -= new Vector3(0, ScrollSpeed * Time.deltaTime);
    }

    public virtual void OffScreenDestruction()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        //Debug.Log("Screen Position: " + screenPosition.x);
        if (screenPosition.x < widthTreshold.x || screenPosition.x > (Screen.width + widthTreshold.y) || screenPosition.y < heightTreshold.x )
            this.gameObject.SetActive(false);
    }
}
