using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private Transform _spawn;


    public void Create()
    {
        Instantiate(_objectPrefab, new Vector3(_spawn.position.x, _spawn.position.y, 0f), Quaternion.identity);
    }
}
