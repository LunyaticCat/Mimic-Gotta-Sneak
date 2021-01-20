using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    
    private CountdownTimer gameOver;
    private GameObject timerGameObject;
    private PlayerControl player;
    void Start()
    {
        timerGameObject = GameObject.Find("timer");
        gameOver = timerGameObject.GetComponent<CountdownTimer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
    }

    void FixedUpdate()
    {
        if (GetComponent<BoxCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
        {
            gameOver.gameOver("You win !");
        }
    }
}
