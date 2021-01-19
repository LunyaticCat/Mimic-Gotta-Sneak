using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    private float currentTime = 0;

    public float startingTime = 60;

    public Text timer;

    public Button quitButton;
    public Button reloadButton;
    
    // Start is called before the first frame update
    void Start()
    {
        quitButton.gameObject.SetActive(false);
        reloadButton.gameObject.SetActive(false);
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
            gameOver();
            timer.text = "00:00\nTIMES UP !";
            enabled = false;
        }
    }

    private void gameOver()
    {
        timer.color=Color.red;
        timer.fontSize = 250;
        timer.transform.Translate( 787, -365.78f, 0);
        timer.alignment = TextAnchor.MiddleCenter;
        quitButton.gameObject.SetActive(true);
        reloadButton.gameObject.SetActive(true);
        Time.timeScale = 0;
        
    }
}
