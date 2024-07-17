using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
private float speed;
private float jumpForce;
private float movementHorizontal;
private Rigidbody2D rb2D;


{
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");

    }

    private void fixedUpdate(){
        
    }
}
