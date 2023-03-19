using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCreator : MonoBehaviour
{
    [SerializeField] private Carrot _carrotPrefab;
    [SerializeField] private Transform _spawn;


    public void Attack()
    {
        Instantiate(_carrotPrefab, _spawn.position, Quaternion.identity);
    }
}
