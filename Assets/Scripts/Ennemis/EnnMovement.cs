using System;
using UnityEngine;

public class EnnMovement : MonoBehaviour
{
    public float speed = 1;
    public GameObject leftBorder;
    public GameObject rightBorder;
    private bool _faceLeft;
    private bool[] _pursuitInfos = {false, false};
    private float _xMax;
    private float _xMin;

    private void Start()
    {
        _xMin = leftBorder.transform.position.x;
        _xMax = rightBorder.transform.position.x;
        leftBorder.GetComponent<Renderer>().enabled = false;
        rightBorder.GetComponent<Renderer>().enabled = false;
        Physics2D.IgnoreLayerCollision(3, 7, true);
        _faceLeft = false;
        _pursuitInfos[0] = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_pursuitInfos[0])
        {
            speed = 5;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
        var xEnn = transform.position.x;
        if (xEnn < _xMin)
        {
            if (_faceLeft)
            {
                _faceLeft = false;
                transform.Rotate(new Vector3(0, 180, 0));
            }
        }
        else if (xEnn > _xMax)
        {
            if (!_faceLeft)
            {
                _faceLeft = true;
                transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }

    public bool GETFaceLeft()
    {
        return _faceLeft;
    }

    public void enablePursuit(bool playerAtLeft)
    {
        _pursuitInfos = new bool[] {true, true};
        Physics2D.IgnoreLayerCollision(3, 7, false);
    }

    public void disablePursuit()
    {
        _pursuitInfos[0] = false;
        speed = 1;
        Physics2D.IgnoreLayerCollision(3, 7, true);
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.CompareTag("Player"))
        {
            Debug.Log("Fin du jeu !");
            // GAME OVER
        }
    }
}