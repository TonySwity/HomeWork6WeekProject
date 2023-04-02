using UnityEngine;
using UnityEngine.Serialization;

public class LootBullets : MonoBehaviour
{
    [SerializeField] private int _gunIndex = 1;
    [SerializeField] private int _numberOfBullets = 30;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.TryGetComponent(out PlayerArmory playerArmory))
        {
            playerArmory.AddBullets(_gunIndex, _numberOfBullets);
            Destroy(gameObject);
        }
    }
}
