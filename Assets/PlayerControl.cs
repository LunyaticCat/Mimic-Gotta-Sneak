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

         void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.tag == "Ground")
            {
                canJump = false;
                Debug.Log("can't jump");
            }
        }

         void OnCollisionExit(Collision collision)
        {
            if (collision.collider.tag == "Ground")
            {
                canJump = true;
                Debug.Log("can jump");
            }
        }

        if (Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }
}
