using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Hook : MonoBehaviour
{
    [SerializeField] private Collider _collision;
    [SerializeField] private Collider _playerCollision;
    [SerializeField] private RopeGun _ropeGun;
    
    private FixedJoint _fixedJoint;
    public Rigidbody Rigidbody { get; set; }

    private void Awake()
    {
        Physics.IgnoreCollision(_collision,_playerCollision);
        Rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();
            
            if (collision.rigidbody)
            {
                _fixedJoint.connectedBody = collision.rigidbody;
            }
            
            _ropeGun.CreateSpring();
        }
       
    }

    public void StopFix()
    {
        if (_fixedJoint)
        {
            Destroy(_fixedJoint);
        }
    }
}
