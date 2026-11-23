using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D), typeof(Animator))]
public class TouchingDirections : MonoBehaviour
{
    [SerializeField] private ContactFilter2D castFilter;
    [SerializeField] private float groundCheckDistance = 0.05f;
    private CapsuleCollider2D col;
    private Animator anim;
    private RaycastHit2D[] groundHits = new RaycastHit2D[5];
    public bool isGrounded;

    private void Awake()
    {
        col = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        CheckForGround();
    }

    private void CheckForGround()
    {
        isGrounded = col.Cast(Vector2.down, castFilter, groundHits, groundCheckDistance) > 0;
        anim.SetBool("isGrounded", isGrounded);
    }
}
