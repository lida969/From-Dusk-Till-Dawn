using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    private Animator _animator;
    private Collider _collider;
    private EnemyMove _enemyMove;
    public static int score;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
        _enemyMove = GetComponent<EnemyMove>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _animator.SetTrigger("death");
            //_collider.enabled = false;
            _enemyMove.enabled = false;
            /*if (_animator.SetTrigger("death"))
            {

            }*/
            Destroy(gameObject, 2f);
        }
    }
}