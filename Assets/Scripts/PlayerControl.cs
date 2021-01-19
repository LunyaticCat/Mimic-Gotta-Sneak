using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public CapsuleCollider2D groundDetector;
    public float speed = 5;
    public float jump = 100;
    private float move;
    public Animator animator;
    private bool facingRight = true;
    private bool jumpPressed;
    private bool sneak = false;
    private int nbCoins = 0;

    public void addCoin(int n)
    {
        nbCoins += n;
        Debug.Log(nbCoins);
    }

    void GroundedUpdater()
    {
    }


    void Update()
    {
        move = Input.GetAxis("Horizontal");


        if (sneak)
        {
            if (GetComponent<Light>().range != 5)
            {
                GetComponent<Light>().range = Convert.ToSingle(Math.Round(GetComponent<Light>().range) - 1);
            }
        }
        else if (rb.velocity[0] <= 1 && rb.velocity[0] >= -1 && rb.velocity[1] >= -1 && rb.velocity[1] <= 1)
        {
            if (GetComponent<Light>().range < 25)
            {
                GetComponent<Light>().range = Convert.ToSingle(Math.Round(GetComponent<Light>().range) + 1);
            }
            else
            {
                GetComponent<Light>().range = Convert.ToSingle(Math.Round(GetComponent<Light>().range) - 1);
            }
        }
        else
        {
            if (GetComponent<Light>().range != 100)
            {
                GetComponent<Light>().range = Convert.ToSingle(Math.Round(GetComponent<Light>().range) + 1);
            }
        }

        if (Input.GetButtonDown("Jump") && groundDetector.IsTouchingLayers())
        {
            jumpPressed = true;
        }

        if (Input.GetButtonDown("Vertical") && groundDetector.IsTouchingLayers())
        {
            sneak = true;
        }

        if (Input.GetButtonUp("Vertical"))
        {
            sneak = false;
        }

        Flip(move);
    }

    void FixedUpdate()
    {
        GroundedUpdater();
        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetBool("Sneak", sneak);
        if (!sneak)
        {
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }

        if (jumpPressed && groundDetector.IsTouchingLayers())
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
            jumpPressed = false;
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