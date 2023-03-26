using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SetAnimatorTriggerEveryNSecond : MonoBehaviour
{
    [FormerlySerializedAs("_attackPeriod")]
    [SerializeField] private float _period = 3f;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _triggerName = "Attack";

    private float _timer;
    
    public UnityEvent EventOnAttack;
    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer > _period)
        {
            _timer = 0f;
            
            _animator.SetTrigger(_triggerName);
            EventOnAttack?.Invoke();
        }
    }
}
