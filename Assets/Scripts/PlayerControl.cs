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
    public Animator animator;
    private bool facingRight = true;

    bool grounded = false;

    void GroundedUpdater()
    {
    }

    void Update()
    {
        GroundedUpdater();

        if (rb.velocity[0] <= 1 && rb.velocity[0] >= -1 && rb.velocity[1] >= -1 && rb.velocity[1] <= 1)
        {
            if (GetComponent<Light>().range >= 25)
            {
                GetComponent<Light>().range--;
            }
        }
        else
        {
            if (GetComponent<Light>().range <= 100)
            {
                GetComponent<Light>().range++;
            }
        }

        move = Input.GetAxis("Horizontal");
        Flip(move);
        animator.SetFloat("Speed", Mathf.Abs(move));
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && groundDetector.IsTouchingLayers())
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}