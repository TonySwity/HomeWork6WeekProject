using UnityEngine;

public class Acorn : MonoBehaviour
{
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _maxAngularSpeed = 180f;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.AddRelativeForce(_velocity, ForceMode.VelocityChange);
        _rigidbody.angularVelocity = new Vector3(
            Random.Range(-_maxAngularSpeed, _maxAngularSpeed), 
            Random.Range(-_maxAngularSpeed, _maxAngularSpeed), 
            Random.Range(-_maxAngularSpeed, _maxAngularSpeed)
            );
    }
}
