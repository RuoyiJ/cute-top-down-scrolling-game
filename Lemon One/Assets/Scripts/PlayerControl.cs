using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerControl : MonoBehaviour, IPlayerController {
    private Rigidbody2D rigid;
    [SerializeField]
    private float speed;

    private ICollidable m_collidable;
    private int m_currentLives = 3;
    private int m_currentPrawns = 0;
    private int m_score = 0;
    public int currentLives
    {
        get { return m_currentLives; }
        set { m_currentLives = value; }
    }
    public int currentPrawns
    {
        get { return m_currentPrawns; }
        set { m_currentPrawns = value; }
    }
    public int currentScore
    {
        get { return m_score; }
        set { m_score = value; }
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        InGameUI.UpdateUI(this);
    }

    // Update is called once per frame
    void Update () {
        HandleInput();
        HandleColllision();
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigid.velocity = new Vector2(0, 1) * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigid.velocity = new Vector2(0, -1) * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigid.velocity = new Vector2(1, 0) * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rigid.velocity = new Vector2(-1, 0) * speed * Time.deltaTime;
        }
        else rigid.velocity = Vector2.zero;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(enabled && m_collidable == null &&
            (m_collidable = other.GetComponent<ICollidable>()) != null &&
            !m_collidable.enabled)
        {
            m_collidable = null;
        }
        //Debug.Log("Touch Collidable? " + (m_collidable != null));
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if(m_collidable!=null && m_collidable == other.GetComponent<ICollidable>())
        {
            m_collidable = null;
        }

    }

    private void HandleColllision()
    {
        if(m_collidable != null && m_collidable.enabled)
        {
            m_collidable.CollisionResolve();
            InGameUI.UpdateUI(this);
            m_collidable = null;
            //Destroy GameObject when lives = 0
            if (currentLives <= 0)
                Destroy(gameObject);

        }
    }
}
