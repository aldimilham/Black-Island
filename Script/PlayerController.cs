using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
    private float moveVelocity;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    private Rigidbody2D theRB;

    public Transform groundCheckpoint;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    public bool isGrounded;

    private Animator anim;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;

    public bool onLadder;
    public float climbSpeed;
    public float climbVelocity;
    public float gravityStore;

    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        gravityStore = theRB.gravityScale;

    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, groundCheckRadius, whatIsGround);

        moveVelocity = 0f;

        //moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(left))
        {
            //theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
            moveVelocity = -moveSpeed;
        }
        else if (Input.GetKey(right))
        {
            //theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
            moveVelocity = moveSpeed;
        }
        //else
        //{
            //theRB.velocity = new Vector2(0, theRB.velocity.y);
        //}

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-0.15f, 0.15f, 1);
        } else if(theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(0.15f, 0.15f, 1);
        }

        if(knockbackCount <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        } else
        { 
            if (knockFromRight)
                theRB.velocity = new Vector2(-knockback, knockback);
            if (!knockFromRight)
                theRB.velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;
        }

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);

        if (onLadder)
        {
            theRB.gravityScale = 0f;

            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");

            theRB.velocity = new Vector2(theRB.velocity.x, climbVelocity);
        }

        if (!onLadder)
        {
            theRB.gravityScale = gravityStore;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "MovingPlatform")
        {
            transform.parent = collision.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "MovingPlatform")
        {
            transform.parent = null;
        }
    }

}
