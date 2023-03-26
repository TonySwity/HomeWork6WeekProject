using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Enemy[] _enemies;
    private PlayerHealth _player;

    private void Start()
    {
        _player = FindObjectOfType<PlayerHealth>();
        _enemies = FindObjectsOfType<Enemy>();

        foreach (var enemy in _enemies)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        foreach (var enemy in _enemies)
        {
            if (Vector3.Distance(enemy.transform.position,_player.transform.position) == 50f)
            {
                enemy.gameObject.SetActive(true);
            }
        }
    }
}
