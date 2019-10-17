using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour, IPlayerController {
    //private Rigidbody2D rigid;
    [SerializeField]
    private float speed;

    private ICollidable m_collidable;
    private int m_currentLives = 1;
    private int m_currentPrawns = 0;
    private int m_score = 0;
    private int m_gridIndex = 2;
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

    public int currentGridIndex
    {
        get { return m_gridIndex; }
        set { m_gridIndex = value; }
    }

    public bool IsMoving { get; set; }

    private void Start()
    {
        //rigid = GetComponent<Rigidbody2D>();
        IsMoving = false;
        //CollisionEvents.OnObstacleCollision += ResetPlayer;
    }

    // Update is called once per frame
    void Update() {
        HandleInput();
        HandleColllision();
    }

    void HandleInput()
    {
        SpriteRenderer sprRen = GetComponent<SpriteRenderer>();
        float width = sprRen.sprite.bounds.size.x;
        float minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0)).x + width;
        float maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x - width;
        if (IsMoving)
        {
            if (Input.GetKeyDown(KeyCode.D)  || (Input.GetKeyDown(KeyCode.RightArrow))|| (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width/2))
            {
                if (m_gridIndex < 4)
                {//rigid.velocity = new Vector2(1, 0) * speed * Time.deltaTime;
                    m_gridIndex++;
                    HorizontalMovement(m_gridIndex);
                }
            }
            else if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetMouseButtonDown(0) && Input.mousePosition.x < Screen.width / 2))
            {
                if (m_gridIndex > 0)
                {//rigid.velocity = new Vector2(-1, 0) * speed * Time.deltaTime;
                    m_gridIndex--;
                    HorizontalMovement(m_gridIndex);
                }
            }
        }
    }
    private void HorizontalMovement(int index)
    {
        int x = Grid.XPosition(index);
        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(x, 0));
        pos = new Vector3(pos.x, transform.position.y);
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * 100);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(enabled && m_collidable == null &&
            (m_collidable = other.GetComponent<ICollidable>()) != null &&
            !m_collidable.enabled)
        {
            m_collidable = null;
        }
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
            PlayerDataRef.currentScore = currentScore;
            PlayerDataRef.currentPrawns = currentPrawns;
            //Destroy GameObject when lives = 0
            if (currentLives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    // not working well
    public void ResetPlayer()
    {
        StartCoroutine(DisableCollisionForSomeTime(2f));
    }

    IEnumerator DisableCollisionForSomeTime(float waitTime)
    {
        enabled = false;
        yield return new WaitForSecondsRealtime(waitTime);
        enabled = true;
    }
}
