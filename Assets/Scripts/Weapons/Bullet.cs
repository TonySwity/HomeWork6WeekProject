using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject _effectPrefab;
    [field: SerializeField] public int Damage { get; private set; }

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(_effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
