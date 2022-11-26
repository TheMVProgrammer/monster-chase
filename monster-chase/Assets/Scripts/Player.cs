using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 10f; // Variable that we are going to use to move the player.
                                     
    public float jumpForce = 11f; // Variable that we are going to use to manage jump movement.
   
    private float movementX;

    private Rigidbody2D rb;

    private SpriteRenderer sr;

    private Animator animator;

    private readonly string WALK_ANIMATION = "Walk";

    private bool isGrounded;

    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboad();
        AnimatePlayer();
        PlayerJump();
    }
    void PlayerMoveKeyboad()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += moveForce * Time.deltaTime * new Vector3(movementX, 0f, 0f);
    }

    void AnimatePlayer()
    {   
        if (movementX > 0f)
        {
            // We are going to the right side
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }   
        else if (movementX < 0f)
        {
            // We are going to the left side
            animator.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            animator.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(GROUND_TAG))
            isGrounded = true;

        if (collision.gameObject.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ENEMY_TAG))
            Destroy(gameObject);
    }

} // class


