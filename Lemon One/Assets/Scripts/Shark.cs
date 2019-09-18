using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : CollidableController {

	public override CollidableType collidable
    {
        get { return CollidableType.Shark; }
    }
}
