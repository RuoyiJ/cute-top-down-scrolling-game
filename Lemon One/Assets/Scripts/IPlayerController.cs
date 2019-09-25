using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerController {

	bool enabled { get; }

    int currentLives { get; set; }
    int currentPrawns { get; set; }
    int currentScore { get; set; }
    int currentGridIndex { get; set; }
    bool IsMoving { get; set; }

}
