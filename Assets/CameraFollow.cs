using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform following;

    public float smoothness = 0.125f;
    public Vector3 offset = new Vector3(0,1,-1);

    void FixedUpdate()
    {
        Vector3 finalPostion;
        if(following.position.x>5 && following.position.y>2 && following.position.x<1995){
            finalPostion = following.position + offset;
        }
        else
        {
            finalPostion = new Vector3(5, following.position.y, following.position.z) + offset;
        }
        
        transform.position = Vector3.Lerp(transform.position, finalPostion, smoothness);
    }
}
