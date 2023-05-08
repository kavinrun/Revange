using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Rigidbody2D rb;

    public float moveSpeed;
    public float jumpForce;
    public float attack;
    public float health;

    protected void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Basic Movement
    protected void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);

        float horizontalFlip = Input.GetAxisRaw("Horizontal");
        if (horizontalFlip != 0)
        {
            transform.localScale = new Vector3(horizontalFlip, 1, 1);
        }
    }
}
