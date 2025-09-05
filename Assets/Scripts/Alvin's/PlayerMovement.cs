using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player body")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private Animator animator;
    [SerializeField] private TrailRenderer tr;

    [Header("Cat power")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;

    [Header("Grounding")]
    [SerializeField] private Transform feetPos;
    [SerializeField] private float checkRadius;
    private bool isGrounded;
    private GameObject currentOneWayPlatform;
    public LayerMask whatIsGround;

    [Header("Other")]
    [SerializeField] private float jumpStartTime;
    private float jumpTime;
    private bool isJumping;
    private float moveInput;

    private bool canDash = true;
    private bool isDashing;
    



    void Update()
    {
        if(isDashing)
        {
            return;
        }

            moveInput = Input.GetAxisRaw("Horizontal");
            FaceMoveDirection();
            Jump();
        
        

        animator.SetBool("Moving", Mathf.Abs(moveInput) > 0.01f);

        bool isReallyGrounded = isGrounded && Mathf.Approximately(rb.linearVelocity.y, 0f);
        animator.SetBool("Grounded", isReallyGrounded);

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

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
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z); // Menghadap kanan
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z); // Menghadap kiri
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.4f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.linearVelocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}
