using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("敌人属性")]
    public int maxHealth = 3;
    public int attackDamage = 1;
    public float moveSpeed = 1.5f;
    public float attackRange = 0.8f;
    public float attackCooldown = 1.2f;
    public float noticeRange = 5f;
    public Transform player;

    [Header("受击与死亡音效")]
    public AudioSource audioSource;
    public AudioClip hurtSound;
    public AudioClip deathSound;

    [Header("攻击音效")]
    public AudioClip attackSound;

    private Rigidbody2D rb;
    private Animator anim;
    private int currentHealth;
    private float lastAttackTime;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }
    }

    void Update()
    {
        if (isDead) return;
        if (player == null) return;

        if (anim != null) anim.SetBool("isMoving", rb.velocity.x != 0);

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < noticeRange)
        {
            float direction = Mathf.Sign(player.position.x - transform.position.x);

            if (direction > 0.01f)
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (direction < -0.01f)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }

            if (distance > attackRange)
            {
                rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
            }
            else if (Time.time > lastAttackTime + attackCooldown)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);

                lastAttackTime = Time.time;
                if (anim != null) anim.SetTrigger("Attack");

                if (audioSource != null && attackSound != null)
                {
                    audioSource.PlayOneShot(attackSound);
                }

                Invoke("DoAttack", 0.4f);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    void DoAttack()
    {
        if (isDead) return;
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < attackRange + 0.2f)
        {
            PlayerHealth health = player.GetComponent<PlayerHealth>();
            if (health != null) health.TakeDamage(attackDamage, transform);
        }
    }

    public void TakeDamage(int damage, Transform attacker)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (anim != null) anim.SetTrigger("isHurt");
        if (audioSource != null && hurtSound != null)
            audioSource.PlayOneShot(hurtSound);

        if (rb != null)
        {
            float direction = Mathf.Sign(transform.position.x - attacker.position.x);
            rb.velocity = new Vector2(direction * 3f, 2f);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        rb.velocity = Vector2.zero;

        if (anim != null) anim.SetTrigger("isDead");
        if (deathSound != null)
            AudioSource.PlayClipAtPoint(deathSound, transform.position);

        Invoke("HideEnemy", 1f);
    }

    void HideEnemy()
    {
        gameObject.SetActive(false);
    }
}