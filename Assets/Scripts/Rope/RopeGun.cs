using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum RopeState
{
    Disabled,
    Fly,
    Active
}
public class RopeGun : MonoBehaviour
{
    [SerializeField] private Hook _hook;
    [SerializeField] private Transform _spawn;
    [SerializeField] private float _speed = 15f;
    [SerializeField] private Transform _ropeStart;
    [SerializeField] private RopeState _currentRopeState;
    [SerializeField] private RopeRenderer _ropeRenderer;
    [SerializeField] private PlayerMove _playerMove;

    private SpringJoint _springJoint;
    private float _lenght;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentRopeState == RopeState.Active && _playerMove.Grounded == false)
            {
                _playerMove.Jump();
            }
            
            DestroySpring();
        }

        if (_currentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(_ropeStart.position, _hook.transform.position);
             
            if (distance > 20f)
            {
                _hook.gameObject.SetActive(false);
                _currentRopeState = RopeState.Disabled;
                _ropeRenderer.Hide();
            }
        }

        if (_currentRopeState != RopeState.Disabled)
        {
            _ropeRenderer.Draw(_ropeStart.position, _hook.transform.position, _lenght);
        }
    }

    private void Shoot()
    {
        _lenght = 1f;
        
        if (_springJoint)
        {
            Destroy(_springJoint);
        }
        _hook.gameObject.SetActive(true);
        _hook.StopFix();
        _hook.transform.position = _spawn.position;
        _hook.transform.rotation = _spawn.rotation;
        _hook.Rigidbody.velocity = _spawn.forward * _speed;

        _currentRopeState = RopeState.Fly;
    }

    public void CreateSpring()
    {
        if (_springJoint == null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();
            _springJoint.connectedBody = _hook.Rigidbody;
            _springJoint.anchor = _ropeStart.localPosition;
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = Vector3.zero;
            _springJoint.spring = 100f;
            _springJoint.damper = 5f;
            _lenght = Vector3.Distance(_ropeStart.position, _hook.transform.position);
            _springJoint.maxDistance = _lenght;

            _currentRopeState = RopeState.Active;
        }
    }

    public void DestroySpring()
    {
        if (_springJoint)
        {
            Destroy(_springJoint);
            _currentRopeState = RopeState.Disabled;
            _hook.gameObject.SetActive(false);
            _ropeRenderer.Hide();
        }
    }
}
