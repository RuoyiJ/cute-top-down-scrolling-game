using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollidableController : MonoBehaviour, ICollidable
{
    protected bool isOffScreen = false;
    public Vector2 widthTreshold;
    public Vector2 heightTreshold;
    public abstract CollidableType collidable { get; }

    public IPlayerController player { get; private set; }

    public float ScrollSpeed { get; private set; }

    protected virtual void Awake()
    {
        player = null;
    }

    protected virtual void Update()
    {
        Scrolling();
        OffScreenDestruction();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(enabled && player == null &&
            (player = other.GetComponent<IPlayerController>())!=null &&
            !player.enabled)
        {
            player = null;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if(player != null && player == other.GetComponent<IPlayerController>())
        {
            player = null;
        }
    }
    public abstract void CollisionResolve();

    public virtual void Scrolling()
    {
        ScrollSpeed = 5f * Level.SpeedMultiplier;
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
