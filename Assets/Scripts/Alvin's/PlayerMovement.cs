using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player body")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D playerCollider;

    [Header("Cat power")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [Header("Grounding")]
    [SerializeField] LayerMask GroundLayer;
    [SerializeField] Transform GroundCheck;

    // other
    private GameObject currentOneWaySurface;
    private float horizontal;

    #region Player Movement
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCapsule(GroundCheck.position, new Vector2(1f, 0.1f), CapsuleDirection2D.Horizontal, 0, GroundLayer);
    }
    #endregion


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)|| Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentOneWaySurface != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWaySurface = collision.gameObject;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWaySurface = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWaySurface.GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.4f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);
    }
}
