using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _colliderTransform;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _friction;
    [SerializeField] private bool _grounded;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _sitDownSpeed = 15f;
    [SerializeField] private Transform _pointerTransform;
    [SerializeField] private Transform _body;
    [SerializeField] private float _rotationSpeed = 2f;

    private float _horizontalInput;

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S) || !_grounded)
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * _sitDownSpeed);
        }
        else
        {
            _colliderTransform.localScale = Vector3.Lerp(_colliderTransform.localScale,Vector3.one, Time.deltaTime * _sitDownSpeed);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _rigidbody.AddForce(0f,_jumpSpeed, 0f, ForceMode.VelocityChange);
        }

        if (_pointerTransform.localRotation.y > 0f)
        {
            _body.localRotation = Quaternion.Lerp(_body.localRotation,Quaternion.Euler(0f, -45f,0f), Time.deltaTime * _rotationSpeed);
        }
        else
        {
            _body.localRotation = Quaternion.Lerp(_body.localRotation,Quaternion.Euler(0f, 45f,0f), Time.deltaTime * _rotationSpeed);
        }
        
    }


    private void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (!_grounded)
        {
            speedMultiplier = 0.2f;
        }

        if (_rigidbody.velocity.x > _maxSpeed && _horizontalInput > 0f)
        {
            speedMultiplier = 0f;
        }
        else if (_rigidbody.velocity.x < -_maxSpeed && _horizontalInput < 0f)
        {
            speedMultiplier = 0f;
        }
        
        _rigidbody.AddForce(_moveSpeed * _horizontalInput * speedMultiplier, 0f, 0f, ForceMode.VelocityChange);
        
        if (_grounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * _friction, 0f, 0f, ForceMode.VelocityChange);
        }
    }


    private void OnCollisionStay(Collision collisionInfo)
    {
        float angle = Vector3.Angle(collisionInfo.contacts[0].normal, Vector3.up);

        for (int i = 0; i < collisionInfo.contactCount; i++)
        {
            if (angle < 45f)
            {
                _grounded = true;
            }
        }
    }


    private void OnCollisionExit(Collision other)
    {
        _grounded = false;
    }

}
