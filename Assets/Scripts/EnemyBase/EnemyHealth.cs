using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health;


    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
