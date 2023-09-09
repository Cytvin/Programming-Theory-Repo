using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _spawnRate = 0.8f;
    private int[] _xSpawnPoints = { -15, 15 };
    private int[] _zSpawnPoints = { -15, 15 };

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true) 
        {
            GameObject enemy = Instantiate(_enemyPrefab, GenerateSpawnPosition(), _enemyPrefab.transform.rotation);
            enemy.transform.LookAt(_player.transform.position);

            yield return new WaitForSeconds(_spawnRate);
        }
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
