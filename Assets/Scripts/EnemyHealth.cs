using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    private Animator _animator;
    bool _alive = true;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _animator.SetTrigger("death");
            GetComponent<PlayerMove>().enabled = false;
            _alive = false;
        }
    }
}