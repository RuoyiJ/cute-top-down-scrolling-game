using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollidableType
{
    Prawn,
    Rubbish,
    Shark
}

public interface ICollidable {
    CollidableType Collidable { get; }
    bool enabled { get; }
    void CollisionResolve();
    void Scrolling();
}
