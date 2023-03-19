using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out Bullet bullet))
        {
            _enemyHealth.TakeDamage(bullet.Damage);
        }
    }
}
