using System;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private Rigidbody _rigidbody;
    private Transform _playerTransform;
    private Vector3 _toPlayerDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.rotation = Quaternion.identity;
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
        _toPlayerDirection = (_playerTransform.position - transform.position).normalized;
        _rigidbody.velocity = _toPlayerDirection * _speed;
    }
}
