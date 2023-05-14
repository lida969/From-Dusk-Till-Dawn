using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Random = UnityEngine.Random;
using System.CodeDom.Compiler;
using Unity.VisualScripting;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _minWalkableDistance;
    [SerializeField] private float _maxWalkableDistance;

    [SerializeField] private float _reachedPointDistance;

    [SerializeField] private GameObject _roamTerget;

    [SerializeField] private float _targetFollowRange;
    [SerializeField] private EnemyAttack _enemyAttack;

    [SerializeField] private float _stopTargetFollowingRange;

    [SerializeField] private AIDestinationSetter _aiDestinationSetter;

    private Player _player;

    private EnemyStates _currentState;
    private Vector3 _roamPosition;

    private void Start()
    {
        _player = FindObjectOfType<Player>();

        _currentState = EnemyStates.Roaming;

        _roamPosition = GenerateRoamPosition();
    }

    
    private void Update()
    {
        switch (_currentState)
        {
            case EnemyStates.Roaming:
                _roamTerget.transform.position = _roamPosition;

                if (Vector3.Distance(gameObject.transform.position, _roamPosition) <= _reachedPointDistance)
                {
                    _roamPosition = GenerateRoamPosition();
                }

                _aiDestinationSetter.target = _roamTerget.transform;

                TryFindPlayer();

                break;

            case EnemyStates.Following:
                _aiDestinationSetter.target = _player.transform;

                if(Vector3.Distance(gameObject.transform.position, _player.transform.position) < _enemyAttack.AttackRange)
                {
                    _enemyAttack.TryAttackPlayer();
                }
                if (Vector3.Distance (gameObject.transform.position, _player.transform.position) > _stopTargetFollowingRange)
                {
                    _currentState = EnemyStates.Roaming;
                }
                break;
        }
    }
    private void TryFindPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position, _player.transform.position) <= _targetFollowRange)
        {
            _currentState = EnemyStates.Following;
        }
    }
    private Vector3 GenerateRoamPosition()
    {
        var roamPosition = _player.transform.position + GenerateRandomDirection() * GenerateRandomWalkableDistance();
        return roamPosition;
    }
    private float GenerateRandomWalkableDistance()
    {
        var randomDistance = Random.Range(_maxWalkableDistance, _maxWalkableDistance);
        return randomDistance;
    }
    private Vector3 GenerateRandomDirection()
    {
        var newDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f,1f));
        return newDirection;
    }
    public enum EnemyStates
    {
        Roaming,
        Following
    }
}
