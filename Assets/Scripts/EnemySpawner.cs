using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    GameObject _position;
    [SerializeField] private GameObject _spawnLine;
    [SerializeField] private GameObject _spawnLine2;

    private int enemyCount = 0;



    //GameObject _player;
    //[SerializeField] private float _spawnInterval;

    /*[SerializeField] private int _mixX;
    [SerializeField] private int _mixY;
    [SerializeField] private int _maxX;
    [SerializeField] private int _maxY;

    [SerializeField] private int _height;

    private float _currentSpawnTimer;
    */

    private void Update()
    {
        var _player = FindObjectOfType<Player>();
        Vector3 point = _spawnLine.transform.position;
        Vector3  point2 = _spawnLine2.transform.position;
        

        Vector3 end = new Vector3(1500f, 0, 0);
       

        //if (point.x <= end.x)
        //{

        if (_player.transform.position.x >= point.x && enemyCount != 10)
        {
            Spawner();
            if (enemyCount == 10)
            {
                enemyCount = 0;
            }

        }
        if (_player.transform.position.x >= point2.x && enemyCount != 10)
        {

            Spawner();
            if (enemyCount == 10)
            {
                enemyCount = 0;
            }

        }

        



        // }





        /*_currentSpawnTimer += Time.deltaTime;

        if (_currentSpawnTimer >= _spawnInterval)
        {
            var enemyInstance = Instantiate(_enemyPrefab);

            var newPosition = GenerateStartPosition();
            enemyInstance.transform.position = newPosition;

            _currentSpawnTimer = 0;
        }*/
    }

    /*private Vector3 GenerateStartPosition()
    {
        var startPos = new Vector3(Random.Range(_mixX, _maxX), _height, Random.Range(_mixY, _maxY));

        return startPos;
    }*/

    private void Spawner()
    {
        
        if (enemyCount <= 10)
        {
            _position = GameObject.FindWithTag("Zombie");
            Transform _enemyPos = _position.transform;
            Quaternion rotation = Quaternion.Euler(0, -90, 0);
            _enemyPos.rotation = rotation;
            //_enemyPos = new Vector3(_enemyPos.x, -90f, _enemyPos.z);
            Destroy(_position);
            Instantiate(_enemyPrefab, _enemyPos.position, Quaternion.identity);
            enemyCount++;
        }
        

    }

} //они бегут влево от игрока. почему?