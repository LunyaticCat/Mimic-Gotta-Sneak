using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnDetection : MonoBehaviour
{
    bool CanSeePlayer()
    {
        RaycastHit hit;
        var rayDirection = playerObject.transform.position - transform.position;
        if (Physics.Raycast(transform.position, rayDirection, hit))
        {
            if (hit.transform.tag == "Player")
            {
                Debug.Log("En vue");
                return true;
            }
            else
            {
                Debug.Log("Pas en vue");
                return false;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
        }
    }