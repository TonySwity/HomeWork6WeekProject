using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatchObjectsCreator : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform[] _spawnPoints;

    public void Attack()
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            Instantiate(_gameObject, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
