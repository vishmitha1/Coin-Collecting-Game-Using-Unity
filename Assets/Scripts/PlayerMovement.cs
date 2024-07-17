using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private float movementHorizontal;
    private Rigidbody2D rb2D;
    private bool isGrounded;
    [SerializeField] private Transform groundCheck;  // Make sure to assign this in the Inspector
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius, whatIsGround);
        movePlayer();
    }

    private void getInput()
    {
        movementHorizontal = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            rb2D.velocity = Vector2.up * jumpForce;
        }
    }

    private void movePlayer()
    {
        rb2D.velocity = new Vector2(movementHorizontal * speed, rb2D.velocity.y);
    }
}
