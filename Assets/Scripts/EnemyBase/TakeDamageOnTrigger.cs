using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private bool _dieOnAnyCollision;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.TryGetComponent(out Bullet bullet))
            {
                _enemyHealth.TakeDamage(bullet.Damage);
                bullet.HitTarget();
            }
        }
        
        if (_dieOnAnyCollision == true)
        {
            if (other.isTrigger == false)
            {
                _enemyHealth.Die();
            }
        }
    }
}

