using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{
    [Header("Combat Stats")]
    public float attackDamage = 10f;
    public float attackCooldown = 0.3f;
    public float blockDuration = 0.5f;
    public float blockReduction = 0.5f;

    [Header("Hitbox")]
    public Vector2 attackHitboxSize = new Vector2(1f, 1f);
    public Vector2 attackHitboxOffset = new Vector2(0.5f, 0);

    private Animator animator;
    private float attackCooldownTimer = 0f;
    private bool isBlocking = false;
    private int comboCounter = 0;
    private const int maxCombo = 3;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAttackCooldown();
    }

    public void Attack(int direction)
    {
        if (attackCooldownTimer <= 0 && !isBlocking)
        {
            comboCounter++;
            if (comboCounter > maxCombo) comboCounter = 1;

            animator.SetTrigger("Attack");
            animator.SetInteger("ComboCount", comboCounter);

            // Create hitbox
            PerformAttack(direction);

            attackCooldownTimer = attackCooldown;
        }
    }

    private void PerformAttack(int direction)
    {
        Vector2 hitboxPos = (Vector2)transform.position + attackHitboxOffset * direction;
        Collider2D[] hits = Physics2D.OverlapBoxAll(hitboxPos, attackHitboxSize, 0);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Enemy"))
            {
                EnemyAI enemy = hit.GetComponent<EnemyAI>();
                if (enemy != null)
                {
                    float actualDamage = attackDamage * (0.8f + comboCounter * 0.1f);
                    enemy.TakeDamage(actualDamage, direction);
                }
            }
        }

        // Visual feedback
        CameraShake.Instance?.Shake(0.1f, 0.05f);
    }

    public void Block()
    {
        if (!isBlocking)
        {
            isBlocking = true;
            animator.SetBool("IsBlocking", true);
            StartCoroutine(BlockDurationRoutine());
        }
    }

    private IEnumerator BlockDurationRoutine()
    {
        yield return new WaitForSeconds(blockDuration);
        isBlocking = false;
        animator.SetBool("IsBlocking", false);
        comboCounter = 0;
    }

    private void UpdateAttackCooldown()
    {
        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }
    }

    public bool TakeDamage(float damage)
    {
        if (isBlocking)
        {
            damage *= (1 - blockReduction);
            animator.SetTrigger("Blocked");
        }
        return true;
    }

    public int GetComboCount()
    {
        return comboCounter;
    }
}
