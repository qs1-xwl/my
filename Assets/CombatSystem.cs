using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    [Header("攻击参数")]
    public int attackDamage = 1;
    public float attackRange = 0.6f;
    public float attackCooldown = 0.4f;
    public Transform attackPoint;
    public LayerMask enemyLayer;

    [Header("体力参数")]
    public float maxStamina = 100f;
    public float staminaRegen = 15f;
    public float defendCost = 20f;

    [Header("防御状态")]
    [HideInInspector] public bool isDefending;

    [Header("攻击音效")]
    public AudioSource audioSource;
    public AudioClip attackSound;

    private Rigidbody2D rb;
    private Animator anim;
    private float currentStamina;
    private float lastAttackTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentStamina = maxStamina;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        isDefending = Input.GetKey(KeyCode.C) && currentStamina > 0;

        if (isDefending)
        {
            currentStamina -= defendCost * Time.deltaTime;
            if (anim != null) anim.SetBool("Defending", true);
        }
        else
        {
            currentStamina += staminaRegen * Time.deltaTime;
            if (anim != null) anim.SetBool("Defending", false);
        }
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

        if (UIManager.Instance != null)
            UIManager.Instance.UpdateStaminaUI(currentStamina);

        if (Input.GetKeyDown(KeyCode.J) && Time.time > lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            if (anim != null) anim.SetTrigger("Attack");

            if (audioSource != null && attackSound != null)
            {
                audioSource.PlayOneShot(attackSound);
            }

            Invoke("DoAttack", 0.15f); 
        }
    }

    void DoAttack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        foreach (Collider2D hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();
            if (enemy != null) enemy.TakeDamage(attackDamage, transform);
        }
    }
}
