using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prawn : CollidableController {

    private int scoreIcrement = 10;

    public override CollidableType Collidable
    {
        get
        {
            return CollidableType.Prawn;
        }
    }

    public override void CollisionResolve()
    {
        if(enabled && player != null)
        {
            //increment player prawns count
            player.currentPrawns++;
            //increment player score
            player.currentScore += scoreIcrement;
            StartCoroutine(DisapearanceAni());
            Debug.Log("Prawns: " + player.currentPrawns);

        }
    }

    private IEnumerator DisapearanceAni()
    {
        //TO DO 1ST: start animation for disappearance
        //TO DO 2ND: LOGIC FOR GAINING A LIVE AFTER EATING 100 PRAWNS
        //enabled = false;
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
