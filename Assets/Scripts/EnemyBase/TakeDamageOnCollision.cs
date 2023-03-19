using UnityEngine;
using UnityEngine.Events;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    [SerializeField] private bool _dieOnAnyCollision;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Bullet bullet))
        {
            _enemyHealth.TakeDamage(bullet.Damage);
            
        }
        if (_dieOnAnyCollision == true)
        {
            _enemyHealth.TakeDamage(1000);
        }
    }
}
