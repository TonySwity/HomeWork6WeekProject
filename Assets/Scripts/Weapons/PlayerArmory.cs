using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    [SerializeField] private Gun[] _guns;
    [SerializeField] private int _currentGunIndex;

    private void Start()
    {
        TakeGunInBox(_currentGunIndex);
    }

    public void TakeGunInBox(int gunIndex)
    {
        _currentGunIndex = gunIndex;
        
        for (int i = 0; i < _guns.Length; i++)
        {
            if (i == gunIndex)
            {
                _guns[i].Activate();
            }
            else
            {
                _guns[i].Deactivate();
            }
        }
    }

    public void AddBullets(int gunIndex, int numberOfBullets)   
    {
        _guns[gunIndex].AddBullets(numberOfBullets);
        TakeGunInBox(gunIndex);
    }
    
}
