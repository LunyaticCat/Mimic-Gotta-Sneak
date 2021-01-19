using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jump;
    private float move;

    private bool canJump = true;

    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }
}
