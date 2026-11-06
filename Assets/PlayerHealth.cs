using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private Animator anim;
    private bool isDead = false;

    [Header(" ‹…À”ÎÀ¿Õˆ“Ù–ß")]
    public AudioSource audioSource;
    public AudioClip hurtSound;
    public AudioClip deathSound;

    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (UIManager.Instance != null) { UIManager.Instance.UpdateHealthUI(currentHealth); }
    }

    public void TakeDamage(int damage, Transform attacker = null)
    {
        if (isDead) return;
        CombatSystem combat = GetComponent<CombatSystem>();
        if (combat != null && combat.isDefending)
        {
            return;
        }

        currentHealth -= damage;
        if (UIManager.Instance != null) { UIManager.Instance.UpdateHealthUI(currentHealth); }
      
        if (anim != null)
        {
            anim.SetTrigger("isHurt");
        }

        if (audioSource != null && hurtSound != null)
        {
            audioSource.PlayOneShot(hurtSound);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            if (attacker != null)
            {
                PlayerController controller = GetComponent<PlayerController>();
                if (controller != null)
                {
                    float direction = Mathf.Sign(transform.position.x - attacker.position.x);
                    controller.ApplyKnockback(direction);
                }
            }
        }
    }
    void Die()
    {
        if (anim != null)
        {
            anim.SetTrigger("isDead");
        }

        if (deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        PlayerController controller = GetComponent<PlayerController>();
        if (controller != null)
        {
            controller.Die();
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;
        }
        Invoke("HidePlayer", 2f);
    }
    void HidePlayer()
    {
        gameObject.SetActive(false);
    }
}