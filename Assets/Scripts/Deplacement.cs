using UnityEngine;


public class Deplacement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private float horizontalMovement;

    public bool isJumping;
    public bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;
    public Transform groundCheckTop;
    public Transform groundCheckBottom;
    public Transform groundCheckTop2;
    public Transform groundCheckBottom2;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void Update()
    {         
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }
    
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        isGrounded = Physics2D.OverlapArea(groundCheckTop.position, groundCheckBottom.position);

        isGrounded = Physics2D.OverlapArea(groundCheckTop2.position, groundCheckBottom2.position);

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
