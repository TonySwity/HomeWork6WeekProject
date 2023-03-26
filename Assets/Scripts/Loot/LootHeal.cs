using UnityEngine;

public class LootHeal : MonoBehaviour
{
    [SerializeField] private int _health = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerHealth playerHealth))
        {
            if (playerHealth.Health < playerHealth.MaxHealth)
            {
                playerHealth.AddHealth(_health);
                Die();
            }
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
