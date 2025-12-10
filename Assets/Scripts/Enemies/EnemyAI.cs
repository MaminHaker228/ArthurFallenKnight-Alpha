using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [Header("Stats")]
    public float health = 30f;
    public float damage = 5f;
    public float moveSpeed = 3f;
    public float detectionRange = 5f;
    public float attackRange = 1f;
    public float attackCooldown = 1f;

    [Header("References")]
    public Transform player;
    private Rigidbody2D rb;
    private Animator animator;

    private float currentHealth;
    private float lastAttackTime = -999f;
    private bool isChasing = false;
    private Vector2 patrolDirection = Vector2.right;
    private int facingDirection = 1;

    private enum EnemyType { ShadowWarrior, CorruptedArcher, VoidEntity }
    public EnemyType enemyType = EnemyType.ShadowWarrior;

    private void Start()
    {
        currentHealth = health;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameObject.tag = "Enemy";

        if (player == null)
        {
            player = FindObjectOfType<PlayerController>()?.transform;
        }
    }

    private void Update()
    {
        if (player == null || currentHealth <= 0) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            isChasing = true;
            ChasePlayer();

            if (distanceToPlayer < attackRange && Time.time >= lastAttackTime + attackCooldown)
            {
                AttackPlayer();
            }
        }
        else
        {
            isChasing = false;
            Patrol();
        }

        UpdateAnimation();
    }

    private void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
        facingDirection = direction.x > 0 ? 1 : -1;
    }

    private void Patrol()
    {
        rb.velocity = new Vector2(patrolDirection.x * moveSpeed * 0.5f, rb.velocity.y);
    }

    private void AttackPlayer()
    {
        lastAttackTime = Time.time;
        animator.SetTrigger("Attack");

        // Simple melee attack
        if (enemyType == EnemyType.ShadowWarrior || enemyType == EnemyType.CorruptedArcher)
        {
            PlayerState playerState = player.GetComponent<PlayerState>();
            if (playerState != null && Vector2.Distance(transform.position, player.position) < attackRange)
            {
                playerState.TakeDamage(damage);
            }
        }
    }

    public void TakeDamage(float damageAmount, int knockbackDirection)
    {
        currentHealth -= damageAmount;
        animator.SetTrigger("TakeDamage");

        // Knockback
        rb.velocity = new Vector2(knockbackDirection * 3f, 2f);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetTrigger("Death");
        rb.velocity = Vector2.zero;
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1f);
    }

    private void UpdateAnimation()
    {
        animator.SetBool("IsChasing", isChasing);
        animator.SetInteger("FacingDirection", facingDirection);
    }
}
