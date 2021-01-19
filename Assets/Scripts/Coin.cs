using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private PlayerControl player;
    public int coinValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    
    void FixedUpdate()
    {
        
        if (GetComponent<CircleCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
        {
            player.addCoin(1);
            Destroy(this.gameObject);
        }
    }
}
