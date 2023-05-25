using JetBrains.Annotations;
using UnityEngine;
using System.Threading;

public class EnemySpawner1 : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    GameObject _position1;
    [SerializeField] private GameObject _spawnLine1;
    


    [SerializeField] private float _spawnInterval;
    private float _currentSpawnTimer1;
    [SerializeField] private int countEnemies1;

    private void Update()
    {
        var _player = FindObjectOfType<Player>();
        Vector3 point1 = _spawnLine1.transform.position;

        _currentSpawnTimer1 += Time.deltaTime;

        if (_currentSpawnTimer1 >= _spawnInterval)
        {
            if (_player.transform.position.x >= point1.x && countEnemies1 >= 0)
            {
                Spawner1();
                countEnemies1--;
            }
            _currentSpawnTimer1 = 0;

        }
    }

    private void Spawner1()
    {
        _position1 = GameObject.FindWithTag("Zombie");
        Transform _enemyPos = _position1.transform;
        Quaternion rotation = Quaternion.Euler(0, -90, 0);
        _enemyPos.rotation = rotation;
        Destroy(_position1);
        Instantiate(_enemyPrefab, _enemyPos.position, Quaternion.identity);
        this.gameObject.SetActive(true);
    }

}