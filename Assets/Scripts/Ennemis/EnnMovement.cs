using System;
using UnityEngine;

public class EnnMovement : MonoBehaviour
{
    public float speed = 5;
    public GameObject leftBorder;
    public GameObject rightBorder;
    private bool _faceLeft;
    private float _xMax;
    private float _xMin;

    private void Start()
    {
        _xMin = leftBorder.transform.position.x;
        _xMax = rightBorder.transform.position.x;
        leftBorder.GetComponent<Renderer>().enabled = false;
        rightBorder.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        var xEnn = transform.position.x;
        if (xEnn < _xMin)
        {
            speed = Math.Abs(speed);
            if (_faceLeft)
            {
                _faceLeft = true;
                transform.Rotate(new Vector3(0, 180, 0));
            }
        }

        else if (xEnn > _xMax)
        {
            speed = -1 * Math.Abs(speed);
            if (!_faceLeft)
            {
                _faceLeft = false;
                transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }

    public bool GETFaceLeft()
    {
        return _faceLeft;
    }
}