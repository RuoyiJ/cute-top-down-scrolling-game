using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollidableType
{
    Prawn,
    Rabbish,
    Sharp
}

public interface ICollidable {
    CollidableType collidable { get; }
    bool enabled { get; }
    void CollisionResolve();
    void Scrolling();
}
