using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
   Left,
   Right
}

public class Walker : MonoBehaviour
{
   [SerializeField] private Transform _pointA;
   [SerializeField] private Transform _pointB;
   [SerializeField] private float _speed;
   [SerializeField] private Direction _currentDirection;
   [SerializeField] private float _stopTime;

   [SerializeField] private Transform _rayStart;

   public UnityEvent EventOnLeftTarget;
   public UnityEvent EventOnRightTarget;
   
   private bool _isStopped;

   private void Start()
   {
      _pointA.parent = null;
      _pointB.parent = null;
   }

   private void Update()
   {
      if (_isStopped)
      {
         return;
      }

      if (_currentDirection == Direction.Left)
      {
         transform.position -= new Vector3(Time.deltaTime * _speed, 0f, 0f);

         if (transform.position.x < _pointA.position.x)
         {
            
            _currentDirection = Direction.Right;
            _isStopped = true;
            StartCoroutine(ContinueWalk());
            EventOnLeftTarget?.Invoke();
         }
      }
      else
      {
         transform.position += new Vector3(Time.deltaTime * _speed, 0f, 0f);
         
         if (transform.position.x > _pointB.position.x)
         {
            _currentDirection = Direction.Left;
            _isStopped = true;
            StartCoroutine(ContinueWalk());
            EventOnRightTarget?.Invoke();
         }
      }

      if (Physics.Raycast(_rayStart.position, Vector3.down, out RaycastHit hit))
      {
         transform.position = hit.point;
      }
      
      

   }

   private IEnumerator ContinueWalk()
   {
      yield return new WaitForSeconds(_stopTime);
      _isStopped = false;
   }

}
