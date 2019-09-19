using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubbish : CollidableController {

    [SerializeField]
    private List<Sprite> sprites = new List<Sprite>();
    private SpriteRenderer rubbishSprite;

    protected Collider2D obsCollider;

    public override CollidableType Collidable
    {
        get
        {
            return CollidableType.Rubbish;
        }
    }
    protected virtual void OnEnable()
    {
        int r = Random.Range(0, 3);
        rubbishSprite = GetComponent<SpriteRenderer>();
        rubbishSprite.sprite = sprites[r];
        obsCollider = GetComponent<BoxCollider2D>();
        obsCollider.enabled = true;
    }

    public override void CollisionResolve()
    {
        if(enabled && Player != null)
        {
            //player's currentLives--
            StartCoroutine(ResetPlayer());

            //TO DO: COROUTINE ON BLINKING PLAYER IMAGE
        }
    }

    private IEnumerator ResetPlayer()
    {
        Player.currentLives--;
        Debug.Log("Lives: " + Player.currentLives);

        obsCollider.enabled = false;
        yield return null;
        
    }

    //void OnCollisionEnter2D(Collision2D other)
    //   {
    //       if (other.collider.tag == "Player")
    //           Destroy(other.gameObject);
    //   }


}
