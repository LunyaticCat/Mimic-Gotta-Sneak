using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public float speed;
    public float jump;
    private float move;
    public GameObject player;
    [SerializeField] private LayerMask groundLayerMask;

    bool grounded = false;

    void GroundedUpdater()
    {
        //Set to false every frame by default
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(player.transform.position, Vector2.down, 0.6f, groundLayerMask);
        // you can increase RaycastLength and adjust direction for your case
        foreach (var hited in hit)
        {
            Debug.Log(hited.collider.gameObject.tag);
            //if (hited.collider.gameObject == gameObject) //Ignore my character
            //continue;
            // Don't forget to add tag to your ground
            if (hited.collider.gameObject.tag == "Ground")
            { //Change it to match ground tag
                Debug.Log("oui");
                grounded = true;
            }
            else
            {
                Debug.Log("non");
                grounded = false;
            }
        }
    }

    void Update()
    {
        GroundedUpdater();

        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }
}
