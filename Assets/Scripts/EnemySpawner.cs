using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _spawnRate = 2f;
    [SerializeField] private float _enemySpeed = 0.5f;
    private int[] _xSpawnPoints = { -15, 15 };
    private int[] _zSpawnPoints = { -15, 15 };
    private int _enemiesKilled = 0;
    private int _enemiesKilledToUpgrade = 10;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true) 
        {
            if (_enemiesKilled == _enemiesKilledToUpgrade)
            {
                Upgrade();
            }

            Enemy enemy = Instantiate(_enemyPrefab, GenerateSpawnPosition(), _enemyPrefab.transform.rotation).GetComponent<Enemy>();
            enemy.SetPlayerPosition(_player.transform.position);
            enemy.SetSpeed(_enemySpeed);

            enemy.IsDead += _player.GetComponent<Player>().KillEnemy;
            enemy.IsDead += IncreaseEnemiesKilledCounter;

            yield return new WaitForSeconds(_spawnRate);
        }
    }

    private void IncreaseEnemiesKilledCounter(int _)
    {
        _enemiesKilled++;
    }

    private void Upgrade()
    {
        _spawnRate = Mathf.Round((_spawnRate - 0.1f) * 10) * 0.1f;
        _enemySpeed = Mathf.Round((_enemySpeed + 0.2f) * 10) * 0.1f;
        _enemiesKilledToUpgrade += 10;
    }

    private Vector3 GenerateSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;

        spawnPosition.z = Random.Range(_zSpawnPoints[0], _zSpawnPoints[1]);

        if (Mathf.Abs(spawnPosition.z) < 10)
        {
            spawnPosition.x = _xSpawnPoints[Random.Range(0, _xSpawnPoints.Length)];
        }
        else
        {
            spawnPosition.x = Random.Range(_xSpawnPoints[0], _xSpawnPoints[1]);
        }

        spawnPosition.y = 0.5f;

        return spawnPosition;
    }
}
