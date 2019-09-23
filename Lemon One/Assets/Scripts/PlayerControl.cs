using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlayerControl : MonoBehaviour, IPlayerController {
    private Rigidbody2D rigid;
    [SerializeField]
    private float speed;

    private ICollidable m_collidable;
    private int m_currentLives = 1;
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
        SpriteRenderer sprRen = GetComponent<SpriteRenderer>();
        float width = sprRen.sprite.bounds.size.x;
        float minX = Camera.main.ScreenToWorldPoint(new Vector3(0,0)).x + width;
        float maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0)).x - width;
        
        if (Input.GetKey(KeyCode.D) && transform.position.x < maxX)
        {
            rigid.velocity = new Vector2(1, 0) * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A) && transform.position.x > minX)
        {
            rigid.velocity = new Vector2(-1, 0) * speed * Time.deltaTime;
        }
        else rigid.velocity = Vector2.zero;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y);
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
            {
                PlayerDataRef.currentScore = currentScore;
                PlayerDataRef.currentPrawns = currentPrawns;
                Destroy(gameObject);
            }

        }
    }
}
