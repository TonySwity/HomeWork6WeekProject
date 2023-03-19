using UnityEngine;
using UnityEngine.Events;

public class Rabbit : MonoBehaviour
{
    [SerializeField] private float _attackPeriod = 3f;
    [SerializeField] private Animator _animator;
    private float _timer;
    
    public UnityEvent EventOnAttack;
    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer > _attackPeriod)
        {
            _timer = 0f;
            
            _animator.SetTrigger("Attack");
            EventOnAttack?.Invoke();
        }
    }
}
