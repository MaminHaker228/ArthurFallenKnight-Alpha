using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [Header("Health & Stamina")]
    public float maxHealth = 100f;
    public float maxStamina = 100f;

    private float currentHealth;
    private float currentStamina;
    private bool isAlive = true;

    private PlayerController controller;
    private Animator animator;

    public delegate void HealthChangedDelegate(float health, float maxHealth);
    public HealthChangedDelegate OnHealthChanged;

    private void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        RegenerateStamina();
    }

    public void TakeDamage(float damage)
    {
        if (!isAlive) return;

        currentHealth -= damage;
        animator.SetTrigger("TakeDamage");

        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    private void RegenerateStamina()
    {
        currentStamina = Mathf.Min(currentStamina + Time.deltaTime * 5, maxStamina);
    }

    private void Die()
    {
        isAlive = false;
        animator.SetTrigger("Death");
        GetComponent<PlayerController>().enabled = false;
    }

    public float GetHealth() => currentHealth;
    public float GetStamina() => currentStamina;
    public bool IsAlive() => isAlive;
}
