using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform following;

    public float smoothness = 0.125f;
    public Vector3 offset = new Vector3(0,1,-1);
    public float offsetRight = 5;
    public float offsetLeft = 1995;
    public float offsetDown = 1;
    
    void FixedUpdate()
    {
        Vector3 finalPostion;
        if(following.position.x>offsetRight  && following.position.x<offsetLeft){
            finalPostion = following.position + offset;
        }
        else
        {
            finalPostion = new Vector3(offsetRight, following.position.y, following.position.z) + offset;
        }

        if (following.position.y<offsetDown)
        {
            finalPostion.y = offsetDown;
        }
        
        transform.position = Vector3.Lerp(transform.position, finalPostion, smoothness);
    }
}
