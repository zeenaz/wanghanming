using UnityEngine;
using UnityEngine.Serialization;

public class CharacterControllerBase : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float JumpForce = 10f;
    public int MaxJumpCount = 2;
    public Transform GroundCheck;
    public float GroundCheckDistance = 0.1f;
    public LayerMask GroundLayer;

    public Rigidbody2D rb;
    [SerializeField]protected int currentJumpCount;
    public bool isGrounded;
    
    //HP state
    public int MaxHP = 3;
    public int CurrentHP;
    
    
    protected virtual void Awake()
    {
        //add rigidbody to this object if it doesn't have one
        if (GetComponent<Rigidbody2D>() == null)
        {
            gameObject.AddComponent<Rigidbody2D>();
        }
        rb = GetComponent<Rigidbody2D>();
        
    }

    protected virtual void Update()
    {
        GroundCheckUpdate();
    }

    protected void GroundCheckUpdate()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, GroundCheckDistance, GroundLayer);
        if (isGrounded && rb.velocity.y <= 0)
        {
            currentJumpCount = 0;
        }
        //reload jump count when player is grounded
        if (isGrounded)
        {
            currentJumpCount = 0;
        }
    }


    protected virtual void Move(float horizontalInput)
    {
        rb.velocity = new Vector2(horizontalInput * MoveSpeed, rb.velocity.y);
    }

    public virtual void Jump()
    {
        if (isGrounded || currentJumpCount < MaxJumpCount)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            currentJumpCount++;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * GroundCheckDistance);
    }
}