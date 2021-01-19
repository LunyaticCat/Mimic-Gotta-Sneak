using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnnMovement : MonoBehaviour


{

    public float speed = 5;
    public GameObject leftBorder;
    public GameObject rightBorder;
    private float xMax;
    private float xMin;
    private bool faceLeft = false;

    void Start()
    {
        xMin = leftBorder.transform.position.x;
        xMax = rightBorder.transform.position.x;
        leftBorder.GetComponent<Renderer>().enabled = false;
        rightBorder.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        float xEnn = transform.position.x;
        if(xEnn < xMin)
        {
            speed = Math.Abs(speed);
            if (faceLeft) { 
                faceLeft = true;
                transform.Rotate(new Vector3(0, 180, 0));
            }
        }
            
        if(xEnn > xMax) {
            speed = -1 * Math.Abs(speed);
            if (!faceLeft)
            {
                faceLeft = false;
                transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}
