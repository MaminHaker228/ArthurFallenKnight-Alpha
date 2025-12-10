using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public Vector2 patrolStartPoint;
    public Vector2 patrolEndPoint;
    public float patrolSpeed = 2f;
    private Vector2 patrolDirection = Vector2.right;

    private void Start()
    {
        patrolStartPoint = transform.position;
        patrolEndPoint = patrolStartPoint + Vector2.right * 5f;
    }

    public Vector2 GetPatrolDirection()
    {
        return patrolDirection;
    }

    public void SetPatrolDirection(Vector2 direction)
    {
        patrolDirection = direction;
    }
}
