using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prawn : CollidableController {

    private int scoreIcrement = 100;

    public override CollidableType Collidable
    {
        get
        {
            return CollidableType.Prawn;
        }
    }

    public override void CollisionResolve()
    {
        if(enabled && Player != null)
        {
            //increment player prawns count
            Player.currentPrawns++;
            if (Player.currentPrawns > 0 && Player.currentPrawns % 5 == 0 && Level.SpeedMultiplier < 2f)
                Level.SpeedMultiplier += 0.12f;
            Debug.Log("speed multiplier: " + Level.SpeedMultiplier);
            //increment player score
            Player.currentScore += scoreIcrement;
            StartCoroutine(DisapearanceAni());

        }
    }

    private IEnumerator DisapearanceAni()
    {
        //TO DO 1ST: start animation for disappearance
        gameObject.SetActive(false);
        yield return null;
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("trigger");
    //    //ContactPoint contact = collision.contacts[0];
    //    if (other.tag == "Player")
    //        Destroy(this.gameObject);
        
    //}
}
