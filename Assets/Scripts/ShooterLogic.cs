using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterLogic : MonoBehaviour
{
    [SerializeField] private EnemyShoot _enemyShoot;
    public Player _player;
    private EnemyStates _currentState;
    Vector3 _newPos;

    void Start()
    {
        _player = FindObjectOfType<Player>();

        _currentState = EnemyStates.Idle; //бездействие 
    }

   
    void Update()
    {
         switch (_currentState)
        {
            case EnemyStates.Idle:
                TryFindPlayer();

                break;
            case EnemyStates.Shooting:
                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) < _enemyShoot.AttackRange)
                {
                    _enemyShoot.TryShootPlayer();
                }
                if (Vector3.Distance(gameObject.transform.position, _player.transform.position) > _enemyShoot.AttackRange)
                {
                    _currentState = EnemyStates.Idle;
                }
                break;
        }
        var _playerPos = _player.transform.position;
        transform.LookAt(new Vector3(_playerPos.x, transform.position.y, _playerPos.z));
        
    }

    public enum EnemyStates
    {
        Idle,
        Shooting
    }

    private void TryFindPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) <= _enemyShoot.AttackRange)
        {
            _currentState = EnemyStates.Shooting;

        }
    }

}
