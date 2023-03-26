using UnityEngine;

public class ObjectAttackCreator : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private Transform _spawn;


    public void Attack()
    {
        Instantiate(_objectPrefab, new Vector3(_spawn.position.x, _spawn.position.y, 0f), _spawn.rotation);
    }
}
