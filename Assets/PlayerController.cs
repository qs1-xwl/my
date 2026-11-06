using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("移动参数")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 18f;

    [Header("地面检测")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float checkRadius = 0.1f;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    private bool isDead = false;
    private bool isKnockedBack = false;

    [Header("跳跃")]
    public int maxJumpCount = 2;
    public AudioSource audioSource;
    public AudioClip jumpSound;

    private int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead) return;

        if (isKnockedBack)
        {
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            return;
        }

        float moveSpeed = walkSpeed;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveSpeed = runSpeed;
        }

        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        
        float originalX = Mathf.Abs(transform.localScale.x);

        if (h > 0.01f)
        {
            transform.localScale = new Vector3(originalX, transform.localScale.y, transform.localScale.z);
        }

        else if (h < -0.01f)
        {
            transform.localScale = new Vector3(-originalX, transform.localScale.y, transform.localScale.z);
        }

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (isGrounded) { jumpCount = maxJumpCount; }

        if (anim != null)
        {
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            anim.SetBool("isGrounded", isGrounded);
            anim.SetFloat("yVelocity", rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && jumpCount >0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount--;

            if (audioSource != null && jumpSound != null) { audioSource.PlayOneShot(jumpSound); }
        }
    }

    public void ApplyKnockback(float direction)
    {
        isKnockedBack = true;
        rb.velocity = new Vector2(direction * 8f, 4f);
        Invoke("ResetKnockback", 0.3f);
    }

    private void ResetKnockback()
    {
        isKnockedBack = false; 
    }
    public void Die()
    {
        isDead = true;
        rb.velocity = Vector2.zero; 
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }
}
