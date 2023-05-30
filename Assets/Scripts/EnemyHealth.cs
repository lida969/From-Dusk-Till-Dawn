using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    private Animator _animator;
    private Collider _collider;
    private EnemyMove _enemyMove;
    public static int score;
    public bool dead = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
        _enemyMove = GetComponent<EnemyMove>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && dead==false)
        {
            _animator.SetTrigger("death");
            _enemyMove.enabled = false;    
            Destroy(gameObject, 2f);
            score = score + 5;
            dead = true;
        }
    }
}