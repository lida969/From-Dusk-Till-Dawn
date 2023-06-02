using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterHealth : MonoBehaviour
{
    private Animator _animator;
    public GameObject _gun;
    
    public static int score;
    public bool dead = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && dead == false)
        {
            Destroy(_gun);
            _animator.SetTrigger("death");
            Destroy(gameObject, 2f);
            score = score + 5;
            dead = true;
        }
    }
}
