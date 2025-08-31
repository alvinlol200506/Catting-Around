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
    

    [SerializeField] private float jumpStartTime;
    private float jumpTime;
    private bool isJumping;
    private float moveInput;



    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        FaceMoveDirection();

        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);    
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetButton("Jump"))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
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
