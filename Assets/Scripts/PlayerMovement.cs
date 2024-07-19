using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private bool faceRight = true;
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        playerAnim.SetBool("IsGrounded", isGrounded);
        movePlayer();
    }

    private void getInput()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        playerAnim.SetFloat("Movement", Mathf.Abs(movementHorizontal));

        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            rb2D.velocity = Vector2.up * jumpForce;
        }
        playerAnim.SetFloat("Jump", rb2D.velocity.y);

        if (movementHorizontal > 0 && !faceRight)
        {
            FlipChar();
        }
        else if (movementHorizontal < 0 && faceRight)
        {
            FlipChar();
        }
    }

    private void movePlayer()
    {
        rb2D.velocity = new Vector2(movementHorizontal * speed, rb2D.velocity.y);
    }

    private void FlipChar()
    {
        faceRight = !faceRight;
        Vector3 flip = transform.localScale;
        flip.x *= -1;
        transform.localScale = flip;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FallDetection"))
        {
            GameManager.Instance.ResetCoins();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
