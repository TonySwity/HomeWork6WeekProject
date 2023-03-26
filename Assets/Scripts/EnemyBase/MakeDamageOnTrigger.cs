using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.attachedRigidbody)
        {
            return;
        }
        if (other.attachedRigidbody.TryGetComponent(out PlayerHealth player))
        {
            player.TakeDamage(_damage);
        }
    }
}
