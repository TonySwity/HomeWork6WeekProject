using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]private List<Enemy> _enemies;
    [SerializeField]private PlayerHealth _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerHealth>();
        _enemies = FindObjectsOfType<Enemy>().ToList();

        foreach (var enemy in _enemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    private void Update()   
    {
        if (_enemies.Count > 0)
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (i >= _enemies.Count)
                {
                    i = 0;
                }
                
                if (Vector3.Distance(_enemies[i].transform.position,_player.transform.position) <= 20f)
                {
                    if (_enemies[i].gameObject.activeSelf == false)
                    {
                        _enemies[i].gameObject.SetActive(true);
                        _enemies.RemoveAt(i);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Беда Враги закончились");
        }
    }
}
