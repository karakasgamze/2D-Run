using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpSpeed = 7f;
    public float direction;
    Rigidbody2D player;

    [Header("GroundCheck")]
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool isTouchingGround;

    public Vector3 respawnPoint;

    GameManager gamemanager;
    public Animator playerAnimation;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        respawnPoint = this.transform.position;
        gamemanager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        Hareket();
        Animasyon();
        
        if (direction > 0f )
        {
            transform.localScale = new Vector2(1f, 1f);
        }
        else if (direction < 0f )
        {
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }
    }

    void Hareket()
    {
        direction = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(direction * speed, player.velocity.y);

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            isTouchingGround = false;
        }
    }

    void Animasyon()
    {
        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));
        playerAnimation.SetBool("isTouchingGround", isTouchingGround);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pumpkin")
        {
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "FallDetector")
        {
            gamemanager.Respawn();
        }

        if (other.gameObject.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
        }
    }
}
