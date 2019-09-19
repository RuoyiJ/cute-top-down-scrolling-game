using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    [SerializeField]
    PlayerControl player;
    [SerializeField]
	SpriteRenderer background;
    [SerializeField]
    RectTransform targetDistancePanel;
    [SerializeField]
    RectTransform gameOverPanel;
    [SerializeField]
    RectTransform completionPanel;
    [SerializeField]
    Text lives, prawns, score;

    public static PlayerControl Player { get; private set; }
    public static SpriteRenderer Background { get; private set; }
    public static RectTransform TargetDistancePanel { get; private set; }
    public static RectTransform GameOverPanel { get; private set; }
    public static RectTransform CompletionPanel { get; private set; }
    public static Text Lives { get; private set; }
    public static Text Prawns { get; private set; }
    public static Text Score { get; private set; }

    void Awake()
    {
        Player = player;
        Background = background;
        TargetDistancePanel = targetDistancePanel;
        GameOverPanel = gameOverPanel;
        CompletionPanel = completionPanel;
        Lives = lives;
        Prawns = prawns;
        Score = score;
    }
}
