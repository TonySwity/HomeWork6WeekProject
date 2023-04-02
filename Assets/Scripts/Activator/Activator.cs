using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Activator : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    public List<ActivateByDistance> ObjectsToActivate = new List<ActivateByDistance>();

    private void Update()
    {
        for (int i = 0; i < ObjectsToActivate.Count; i++)
        {
            ObjectsToActivate[i].CheckDistance(_playerTransform.position);
            
        }
    }
}
