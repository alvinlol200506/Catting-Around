using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player body")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private BoxCollider2D playerCollider;

    [Header("Cat power")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [Header("Grounding")]
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    // other

    [Header("Other")]
    [SerializeField] private float jumpStartTime;
    private float jumpTime;
    private bool isJumping;
    private float moveInput;



    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        FaceMoveDirection();
        Jump();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);    
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            jumpTime = jumpStartTime;
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        if (Input.GetButton("Jump") && isJumping == true)
        {
            if(jumpTime > 0)
            {
                rb.linearVelocity = Vector2.up * jumpForce;
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }
    void FaceMoveDirection()
    {
        if (moveInput > 0)
        {
            sr.flipX = true;
        }
        else if (moveInput < 0)
        {
            sr.flipX = false;
        }
    }

}
