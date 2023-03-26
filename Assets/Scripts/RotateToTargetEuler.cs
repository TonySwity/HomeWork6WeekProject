using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RotateToTargetEuler : MonoBehaviour
{
    [SerializeField] private Vector3 _leftEuler;
    [SerializeField] private Vector3 _rightEuler;
    [SerializeField] private float _rotationSpeed = 1f;

    private Vector3 _targetEuler;


    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(_targetEuler),Time.deltaTime * _rotationSpeed );
    }

    public void LeftRotation()
    {
        _targetEuler = _leftEuler;
    }

    public void RightRotation()
    {
        _targetEuler = _rightEuler;
    }
}
