using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _timeToReachSpeed = 1f;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 toPlayerDirection = (_playerTransform.position - transform.position).normalized;
        Vector3 force = _rigidbody.mass * (toPlayerDirection * _speed - _rigidbody.velocity) / _timeToReachSpeed;
        
        _rigidbody.AddForce(force);
    }
}
