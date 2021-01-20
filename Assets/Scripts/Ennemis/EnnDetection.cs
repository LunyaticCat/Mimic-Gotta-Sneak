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
    private PlayerControl _playerMovement;
    private float _playerEnemyDistance;
    private bool _playerAtLeft;
    private bool _playerInView;

    // Start is called before the first frame update
    void Start()
    {
        _mimic = GameObject.FindGameObjectWithTag("Player");
        _ennMovement = GetComponent<EnnMovement>();
        _playerMovement = _mimic.GetComponent<PlayerControl>();
        _playerInView = false;
    }

// Update is called once per frame
    void Update()
    {
        if (transform.position.x - _mimic.transform.position.x < 0)
        {
            _playerEnemyDistance = Math.Abs(transform.position.x - _mimic.transform.position.x);
            _playerAtLeft = false;
        }
        else
        {
            _playerEnemyDistance = transform.position.x - _mimic.transform.position.x;
            _playerAtLeft = true;
        }

        if (inViewField())
        {
            if (Math.Tan(Math.PI / 180 * viewAngle) * _playerEnemyDistance >
                Math.Abs(transform.position.y - _mimic.transform.position.y))
            {
                if (!_playerInView)
                {
                    if (!_playerMovement.GETSneak())
                    {
                        _playerInView = true;
                    }
                }
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

        if (_playerInView) _ennMovement.enablePursuit(_playerAtLeft);
        else _ennMovement.disablePursuit();
    }

    private bool inViewField()
    {
        if (_playerEnemyDistance < viewDistance)
        {
            return _ennMovement.GETFaceLeft() && _playerAtLeft ||
                   !_ennMovement.GETFaceLeft() && !_playerAtLeft;
        }

        return false;
    }
}