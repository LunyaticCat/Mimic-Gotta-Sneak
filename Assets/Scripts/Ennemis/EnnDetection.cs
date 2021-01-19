using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class EnnDetection : MonoBehaviour
{
    public float viewDistance = 5;
    public float viewAngle = 30;
    private GameObject _mimic;
    private EnnMovement _ennMovement;
    private float _playerEnemyDistance;
    private bool _playerAtRight = true;
    private bool _playerInView = false;

    // Start is called before the first frame update
    void Start()
    {
        _mimic = GameObject.FindGameObjectWithTag("Player");
        _ennMovement = GetComponent<EnnMovement>();
    }

// Update is called once per frame
    void Update()
    {
        if (transform.position.x - _mimic.transform.position.x < 0)
        {
            _playerEnemyDistance = Math.Abs(transform.position.x - _mimic.transform.position.x);
            _playerAtRight = false;
        }
        else
        {
            _playerEnemyDistance = transform.position.x - _mimic.transform.position.x;
            _playerAtRight = true;
        }

        if (inViewField())
        {
            if (Math.Tan(Math.PI / 180 * viewAngle) * _playerEnemyDistance >
                Math.Abs(transform.position.y - _mimic.transform.position.y))
            {
                _playerInView = true;
            }
            else
            {
                _playerInView = false;
            }
        }
        else
        {
            _playerInView = false;
        }
    }

    private bool inViewField()
    {
        if (_playerEnemyDistance < viewDistance)
        {
            return _ennMovement.GETFaceLeft() && _playerAtRight || !_ennMovement.GETFaceLeft() && !_playerAtRight;
        }

        return false;
    }

    public bool getPlayerInView()
    {
        return _playerInView;
    }
}