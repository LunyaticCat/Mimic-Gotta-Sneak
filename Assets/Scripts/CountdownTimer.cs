using System;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    private float currentTime = 0;

    public float startingTime = 60;

    private String finalString;

    public Text timer;

    public Button quitButton;
    public Button reloadButton;
    
    private Text nbCoin;
    private GameObject nbCoinGameObject;
    private PlayerControl player;
    
    // Start is called before the first frame update
    void Start()
    {
        quitButton.gameObject.SetActive(false);
        reloadButton.gameObject.SetActive(false);
        nbCoinGameObject = GameObject.Find("nbCoinText");
        nbCoin = nbCoinGameObject.GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime<=20.0 && currentTime>=11.0)
        {
            if (((int) (currentTime*2))%2 == 0)
            {
                timer.color=Color.yellow;    
            }
            else
            {
                timer.color = Color.red;
            }
        }
        else if(currentTime<11.0)
        {
            if (((int) (currentTime*5))%2 == 0)
            {
                timer.color=Color.yellow;    
            }
            else
            {
                timer.color = Color.red;
            }
        }

        timer.text = currentTime.ToString("00.00");
        
        if (currentTime<=0.0)
        {
            gameOver("00:00\nTIMES UP !");
        }
    }

    public void gameOver(String finalString)
    {
        Time.timeScale = 0;
        enabled = false;
        timer.color=Color.red;
        nbCoin.color=Color.red;
        timer.fontSize = 250;
        nbCoin.fontSize = 200;
        timer.text = finalString;
        int finalScore = (int) (player.getCoin() * currentTime);

        nbCoin.text = "Score: " + finalScore;
        nbCoin.transform.position = new Vector3(960, 860, 0);
        timer.transform.position = new Vector3(960, 600, 0);
        nbCoin.alignment = TextAnchor.MiddleCenter;
        timer.alignment = TextAnchor.MiddleCenter;
        quitButton.gameObject.SetActive(true);
        reloadButton.gameObject.SetActive(true);
        
    }
}
