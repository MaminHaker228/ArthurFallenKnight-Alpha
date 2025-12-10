using UnityEngine;
using System.Collections;

public class MiniBoss : MonoBehaviour
{
    [Header("Boss Stats")]
    public float maxHealth = 150f;
    public float phase1Damage = 8f;
    public float phase2Damage = 12f;
    public float moveSpeed = 4f;
    public float attackCooldown = 1.2f;

    private float currentHealth;
    private int currentPhase = 1;
    private float lastAttackTime = -999f;
    private Rigidbody2D rb;
    private Animator animator;
    private Transform player;
    private bool isAlive = true;

    private void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameObject.tag = "Enemy";

        player = FindObjectOfType<PlayerController>()?.transform;
    }

    private void Update()
    {
        if (!isAlive || player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Movement
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);

        // Attack pattern
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            if (currentPhase == 1)
            {
                BossAttackPhase1();
            }
            else
            {
                BossAttackPhase2();
            }
            lastAttackTime = Time.time;
        }

        // Phase transition
        if (currentPhase == 1 && currentHealth < maxHealth * 0.5f)
        {
            TransitionToPhase2();
        }

        animator.SetInteger("Phase", currentPhase);
    }

    private void BossAttackPhase1()
    {
        animator.SetTrigger("AttackWave");
        // Wave attack logic here
        DealDamageToPlayer(phase1Damage);
    }

    private void BossAttackPhase2()
    {
        animator.SetTrigger("AttackShockwave");
        // Enhanced attack with dash rush
        StartCoroutine(DashAttack());
        DealDamageToPlayer(phase2Damage);
    }

    private IEnumerator DashAttack()
    {
        float dashDuration = 0.3f;
        float elapsed = 0;

        while (elapsed < dashDuration)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * (moveSpeed * 2);
            elapsed += Time.deltaTime;
            yield return null;
        }

        rb.velocity = Vector2.zero;
    }

    private void TransitionToPhase2()
    {
        currentPhase = 2;
        animator.SetTrigger("Phase2");
        moveSpeed *= 1.2f;
        attackCooldown *= 0.8f;
    }

    private void DealDamageToPlayer(float damage)
    {
        PlayerState playerState = player.GetComponent<PlayerState>();
        if (playerState != null && Vector2.Distance(transform.position, player.position) < 2f)
        {
            playerState.TakeDamage(damage);
        }
    }

    public void TakeDamage(float damageAmount, int knockbackDirection)
    {
        currentHealth -= damageAmount;
        animator.SetTrigger("TakeDamage");

        rb.velocity = new Vector2(knockbackDirection * 5f, 3f);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isAlive = false;
        animator.SetTrigger("Death");
        rb.velocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;
        // Trigger reward/completion
        Destroy(gameObject, 2f);
    }
}
