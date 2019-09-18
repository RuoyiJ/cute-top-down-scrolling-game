using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbish : CollidableController {

    public List<Sprite> sprites = new List<Sprite>();
    SpriteRenderer rabbishSprite;
    Collider2D rCollider;

    public override CollidableType collidable
    {
        get
        {
            return CollidableType.Rabbish;
        }
    }
    private void OnEnable()
    {
        int r = Random.Range(0, 3);
        rabbishSprite = GetComponent<SpriteRenderer>();
        rabbishSprite.sprite = sprites[r];
        rCollider = GetComponent<BoxCollider2D>();
        rCollider.enabled = true;
    }

    public override void CollisionResolve()
    {
        if(enabled && player != null)
        {
            //player's currentLives--
            StartCoroutine(ResetPlayer());

            //TO DO: COROUTINE ON BLINKING PLAYER IMAGE
        }
    }

    private IEnumerator ResetPlayer()
    {
        player.currentLives--;
        Debug.Log("Lives: " + player.currentLives);

        rCollider.enabled = false;
        yield return null;
        
    }

    //void OnCollisionEnter2D(Collision2D other)
    //   {
    //       if (other.collider.tag == "Player")
    //           Destroy(other.gameObject);
    //   }


}
