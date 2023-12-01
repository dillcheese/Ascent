using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static float moveSpeed = 5f;
    private float jumpForce = 13f;
    [SerializeField] private float playerMoveSpeed = moveSpeed;

    [SerializeField] private float horizontal;
    [SerializeField] private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private bool isOnSlipperySurface = false;
    [SerializeField] private bool isOnSuperSlipperySurface = false;

    // Start is called before the first frame update
    private void Start()
    {
        // Get the Rigidbody component attached to the same GameObject
        rb = GetComponent<Rigidbody2D>();

        // Check if the Rigidbody component is found
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on the GameObject.");
        }
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (isOnSlipperySurface)
        {
            rb.AddForce(new Vector2(horizontal * playerMoveSpeed*1.01f, rb.velocity.y));

        }
        else if (isOnSuperSlipperySurface)
        {
            rb.AddForce(new Vector2(horizontal * playerMoveSpeed * 0.105f, 0), ForceMode2D.Impulse);

        }
        else
        {
            rb.velocity = new Vector2(horizontal * playerMoveSpeed, rb.velocity.y);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.35f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;

            // Rotate the player object around the y-axis
            transform.Rotate(0f, 180f, 0f);
            //Vector3 localScale = transform.localScale;
            //localScale.x *= -1f;
            //transform.localScale = localScale;
        }
    }

    public bool getIsFacingRight()
    {
        return isFacingRight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Snow")
        {
            // Slow down player
            playerMoveSpeed = moveSpeed / 2;
        }
        else if (collision.gameObject.tag == "Ice")
        {
            // Make player slippery
            isOnSlipperySurface = true;
        }
        else if (collision.gameObject.tag == "SuperIce")
        {
            // Make player slippery
            isOnSuperSlipperySurface = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Snow")
        {
            // Reset player speed
            playerMoveSpeed = moveSpeed;
        }
        else if (collision.gameObject.tag == "Ice")
        {
            // Make player slippery
            isOnSlipperySurface = false;
        }
        else if (collision.gameObject.tag == "SuperIce")
        {
            // Make player slippery
            isOnSuperSlipperySurface = false;
        }
    }
}