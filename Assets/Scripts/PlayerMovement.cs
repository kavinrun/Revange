using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int moveSpeed = 5;
    [SerializeField]
    private int jumpSpeed = 10;

    private new Rigidbody2D rigidbody;
    private bool jumping = false;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        Vector2 movement = rigidbody.velocity;
        movement.x = Input.GetAxis("Horizontal") * moveSpeed;
        if (!jumping && Input.GetKeyDown(KeyCode.Space))
        {
            movement.y = jumpSpeed;
            jumping = true;
        }
        if (movement == Vector2.zero)
        {
            return;
        }
        rigidbody.velocity = movement;
    }

    private void FixedUpdate()
    {
        if (jumping)
        {
            rigidbody.AddForce(Vector2.down);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (jumping && collision.gameObject.layer == 6)
        {
            jumping = false;
        }
    }
}
