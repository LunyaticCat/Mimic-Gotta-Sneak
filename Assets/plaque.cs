using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plaque : MonoBehaviour
{

    public GameObject doorOpen;
    public GameObject doorClose;


    // Start is called before the first frame update
    void Start()
    {
        doorOpen.active = false;
    }

    void OnTriggerEnter2D()
    {
        doorOpen.active = true;
        doorClose.active = false;
    }
}
