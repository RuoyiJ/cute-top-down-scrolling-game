using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvents : MonoBehaviour {

    public delegate void ObstacleCollision();
    public static ObstacleCollision OnObstacleCollision;

    public static void CollisionOnObstacle()
    {
        CollisionOnObstacle();
    }
}
