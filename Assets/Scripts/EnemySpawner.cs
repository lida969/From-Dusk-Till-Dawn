using JetBrains.Annotations;
using UnityEngine;
using System.Threading;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    GameObject _position;
    [SerializeField] private GameObject _spawnLine;
    [SerializeField] private GameObject _spawnLine2;
    

    [SerializeField] private float _spawnInterval;
    private float _currentSpawnTimer;
    [SerializeField] private int countEnemies;

    private void Update()
    {
        var _player = FindObjectOfType<Player>();
        Vector3 point = _spawnLine.transform.position;

        _currentSpawnTimer += Time.deltaTime;

        if (_currentSpawnTimer >= _spawnInterval)
        {
            if (_player.transform.position.x >= point.x && countEnemies>=0)
            {
                Spawner();
                countEnemies--;
            }
            _currentSpawnTimer = 0;
            
        }
    }

private void Spawner()
    {
        _position = GameObject.FindWithTag("Zombie");
        Transform _enemyPos = _position.transform;
        Quaternion rotation = Quaternion.Euler(0, -90, 0);
        _enemyPos.rotation = rotation;
        Destroy(_position);
        Instantiate(_enemyPrefab, _enemyPos.position, Quaternion.identity);
    }

} 