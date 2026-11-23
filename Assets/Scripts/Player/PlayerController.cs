using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float airWalkSpeed = 1f;
    [SerializeField] private float jumpForce = 5f;
    [Header("Footstep Sounds Settings")]
    [SerializeField] private float stepInterval = 0.2f;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator anim;
    private TouchingDirections touchingDirections;
    private StatueInteraction currentStatue;
    private MovementSounds movementSounds;
    private float stepTimer;
    private bool isFacingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        movementSounds = GetComponent<MovementSounds>();
    }

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleAnimations();
        HandleFootstepSounds();
    }


    private void HandleMovement()
    {
        float speed = touchingDirections.isGrounded ? walkSpeed : airWalkSpeed;
        rb.linearVelocity = new Vector2(moveInput.x * speed, rb.linearVelocity.y);
    }

    private void HandleAnimations()
    {
        anim.SetFloat("Xvelocity", moveInput.x);
        anim.SetFloat("Yvelocity", rb.linearVelocityY);
        if(moveInput.x > 0 && !isFacingRight)
        {
            transform.localScale = new Vector2(1, 1);
            isFacingRight = true;
        }
        else if(moveInput.x < 0 && isFacingRight)
        {
            transform.localScale = new Vector2(-1, 1);
            isFacingRight = false;
        }
    }

    private void HandleFootstepSounds()
    {
        if (touchingDirections.isGrounded && Mathf.Abs(rb.linearVelocityX) > 0.01f)
        {
            stepTimer -= Time.fixedDeltaTime;
            if (stepTimer <= 0f)
            {
                movementSounds?.PlayFootstepSound();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (moveInput.sqrMagnitude > 0)
        {
            FindFirstObjectByType<StartScreenManager>()?.HideScreen();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started && touchingDirections.isGrounded)
        {
            FindFirstObjectByType<StartScreenManager>()?.HideScreen();

            rb.linearVelocityY = jumpForce;
            movementSounds.PlayJumpSound();
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (currentStatue != null)
        {
            currentStatue.Interact();
            Debug.Log("Player interacted with statue");
        }
    }

    public void SetCurrentStatue(StatueInteraction statue)
    {
        Debug.Log("Set statue to " + statue.ToString());
        currentStatue = statue;
    }
}
