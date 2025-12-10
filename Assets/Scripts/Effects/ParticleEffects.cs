using UnityEngine;

public class ParticleEffects : MonoBehaviour
{
    public static void CreateSlashEffect(Vector3 position, Vector2 direction)
    {
        // Instantiate particle effect at position
        GameObject slashEffect = new GameObject("SlashEffect");
        slashEffect.transform.position = position;

        // Add sprite renderer with slash sprite
        SpriteRenderer sr = slashEffect.AddComponent<SpriteRenderer>();
        sr.color = new Color(1, 1, 1, 0.8f);

        // Auto-destroy after duration
        Destroy(slashEffect, 0.3f);
    }

    public static void CreateDashEffect(Vector3 position)
    {
        GameObject dashEffect = new GameObject("DashEffect");
        dashEffect.transform.position = position;

        for (int i = 0; i < 5; i++)
        {
            GameObject particle = new GameObject("Particle");
            particle.transform.parent = dashEffect.transform;
            particle.transform.localPosition = Random.insideUnitCircle * 0.5f;

            SpriteRenderer sr = particle.AddComponent<SpriteRenderer>();
            sr.color = new Color(0.3f, 0.3f, 0.3f, 0.6f);
        }

        Destroy(dashEffect, 0.5f);
    }

    public static void CreateDestructionEffect(Vector3 position)
    {
        GameObject destructionEffect = new GameObject("DestructionEffect");
        destructionEffect.transform.position = position;

        for (int i = 0; i < 8; i++)
        {
            GameObject particle = new GameObject("Shard");
            particle.transform.parent = destructionEffect.transform;
            Rigidbody2D rb = particle.AddComponent<Rigidbody2D>();
            rb.velocity = Random.insideUnitCircle * 5;
        }

        Destroy(destructionEffect, 1f);
    }
}
