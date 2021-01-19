using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void FixedUpdate()
    {
        //Debug.Log(GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()));
        if (GetComponent<CircleCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
        {
            //player.addCoin();
            Debug.Log("Touchaiiiis");
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
