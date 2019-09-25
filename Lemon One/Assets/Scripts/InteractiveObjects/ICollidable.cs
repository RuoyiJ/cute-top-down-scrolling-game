
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
