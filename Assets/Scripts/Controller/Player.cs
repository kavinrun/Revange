using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private Collider2D colli;

    [SerializeField]
    private bool isGround;
    [SerializeField]
    private float feetRayDistance;

    private float FootOffsetX;
    private float FootOffsetY;

    [SerializeField]
    private RaycastHit2D leftFootCheck;
    [SerializeField]
    private RaycastHit2D rightFootCheck;
    [SerializeField]
    private LayerMask groundLayer;

    private void Awake()
    {
        base.Awake();

        colli = transform.GetComponent<Collider2D>();
        FootOffsetX = colli.bounds.size.x/2;
        FootOffsetY = colli.bounds.size.y/2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        base.Movement();
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
            isGround = true;
            rb.sharedMaterial = null;
        }
        else
        {
            isGround = false;
            rb.sharedMaterial = Resources.Load<PhysicsMaterial2D>("Smooth");
        }

        return isGround;
    }

    void Jump()
    {
        if (isGround == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void Dash()
    {

    }
}
