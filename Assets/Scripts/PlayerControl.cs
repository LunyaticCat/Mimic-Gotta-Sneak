using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public BoxCollider2D groundDetector;
    public float speed = 5;
    public float jump = 100;
    private float move;

    bool grounded = false;

    void GroundedUpdater()
    {
        
    }

    void Update()
    {
        GroundedUpdater();

        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && groundDetector.IsTouchingLayers())
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    

}
