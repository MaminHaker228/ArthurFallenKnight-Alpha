using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 0.5f;

    [Header("References")]
    private Rigidbody2D rb;
    private PlayerCombat combatSystem;
    private Animator animator;

    private Vector2 moveInput;
    private bool isDashing = false;
    private float dashCooldownTimer = 0f;
    private int facingDirection = 1; // 1 = right, -1 = left

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        combatSystem = GetComponent<PlayerCombat>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleInput();
        UpdateDashCooldown();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            HandleMovement();
        }
    }

    private void HandleInput()
    {
        moveInput = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput.x = -1;
            facingDirection = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveInput.x = 1;
            facingDirection = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && dashCooldownTimer <= 0 && !isDashing)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            combatSystem.Attack(facingDirection);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            combatSystem.Block();
        }
    }

    private void HandleMovement()
    {
        if (moveInput != Vector2.zero)
        {
            rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        float dashTimer = dashDuration;
        Vector2 dashDirection = new Vector2(facingDirection, 0);

        while (dashTimer > 0)
        {
            rb.velocity = dashDirection * dashSpeed;
            dashTimer -= Time.deltaTime;
            yield return null;
        }

        isDashing = false;
        dashCooldownTimer = dashCooldown;
        rb.velocity = Vector2.zero;
    }

    private void UpdateDashCooldown()
    {
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
    }

    private void UpdateAnimation()
    {
        animator.SetFloat("Speed", moveInput.magnitude);
        animator.SetBool("IsDashing", isDashing);
        animator.SetInteger("FacingDirection", facingDirection);
    }

    public int GetFacingDirection()
    {
        return facingDirection;
    }

    public bool IsDashing()
    {
        return isDashing;
    }
}
