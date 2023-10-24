using UnityEngine;

public class PlatformerPlayerMovementController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public int JumpCount = 2;
    public float JumpForce = 10f;
    public Transform GroundCheck;
    public float GroundCheckRadius = 0.2f;
    public LayerMask GroundLayer;

    private Rigidbody2D rb;
    private CapsuleCollider2D capsuleCollider;

    public int CurrentJumpCount = 0;
    public bool IsGrounded = false;
    public Rigidbody2D Rigidbody => rb;
    
    public Transform EyeTransform;
    
    public bool IsDownJumpGroundCheck { get; private set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);
        if (IsGrounded && rb.velocity.y <= 0)
        {
            CurrentJumpCount = 0;
        }

        MovementInputCheck();
        RotateTowardsMouse();
    }

    public void MovementInputCheck()
    {
        Move();
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded || CurrentJumpCount < JumpCount)
            {
                Jump();
            }
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * MoveSpeed, rb.velocity.y);

        if (horizontal < 0)
        {
            Flip(false);
        }
        else if (horizontal > 0)
        {
            Flip(true);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        IsGrounded = false;
        CurrentJumpCount++;
    }

    protected void Flip(bool isFacingRight)
    {
        transform.localScale = new Vector3(isFacingRight ? 1 : -1, 1, 1);
    }

    private void RotateTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - EyeTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        EyeTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnDrawGizmos()
    {
        if (GroundCheck == null)
            return;

        Gizmos.DrawWireSphere(GroundCheck.position, GroundCheckRadius);
    }
    
    public void SetIsDownJumpGroundCheck(bool value)
    {
        IsDownJumpGroundCheck = value;
    }
}
