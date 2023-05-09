using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;

    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private int jumpCount;
    [SerializeField]
    private int jumpMaxCount;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float attack;
    [SerializeField]
    private float health;
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private float feetRayDistance;

    private float FootOffsetX;
    private float FootOffsetY;

    private bool jumpPressed = false;

    [SerializeField]
    private RaycastHit2D leftFootCheck;
    [SerializeField]
    private RaycastHit2D rightFootCheck;
    [SerializeField]
    private LayerMask groundLayer;

    private PhysicsMaterial2D smoothPhysicsMaterial;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

        FootOffsetX = coll.bounds.size.x/2;
        FootOffsetY = coll.bounds.size.y/2;
    }

    // Start is called before the first frame update
    void Start()
    {
        jumpCount = jumpMaxCount;

        smoothPhysicsMaterial = Resources.Load<PhysicsMaterial2D>("Smooth");
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();

        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
    }

    private void FixedUpdate()
    {
        Movement();

        if (jumpPressed)
        {
            Jump();
        }
    }

    private void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);

        float horizontalFlip = Input.GetAxisRaw("Horizontal");
        if (horizontalFlip != 0)
        {
            if (horizontalFlip > 0)
            {
                horizontalFlip = 1;
            }
            else
            {
                horizontalFlip = -1;
            }
            transform.localScale = new Vector3(horizontalFlip, 1, 1);
        }
    }

    private bool GroundCheck()
    {
        Vector2 pos = transform.position;
        leftFootCheck = Physics2D.Raycast(pos + new Vector2(-FootOffsetX, -FootOffsetY), Vector2.down, feetRayDistance, groundLayer);
        rightFootCheck = Physics2D.Raycast(pos + new Vector2(FootOffsetX, -FootOffsetY), Vector2.down, feetRayDistance, groundLayer);
        Debug.DrawRay(pos + new Vector2(-FootOffsetX, -FootOffsetY), Vector2.down * feetRayDistance, Color.red);
        Debug.DrawRay(pos + new Vector2(FootOffsetX, -FootOffsetY), Vector2.down * feetRayDistance, Color.red);

        if (leftFootCheck || rightFootCheck)
        {
            isGrounded = true;
            jumpCount = jumpMaxCount;
            rb.sharedMaterial = null;
        }
        else
        {
            isGrounded = false;
            rb.sharedMaterial = smoothPhysicsMaterial;
        }

        return isGrounded;
    }

    void Jump()
    {
        if (jumpCount > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
            jumpPressed = false;
        }
        else
        {
            jumpPressed = false;
        }
    }
}
