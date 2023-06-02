using UnityEngine;
using System.Collections;
using System;

public class EnemyHealth : MonoBehaviour
{
    private Animator _animator;
    private Collider _collider;
    private EnemyMove _enemyMove;
    private float beats;
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
            beats = AudioRythm.songPositionInBeats;
            _animator.SetTrigger("death");
            _enemyMove.enabled = false;    
            Destroy(gameObject, 2f);
            dead = true;
            int a = (Convert.ToInt32(beats * 10)) % 10;
            if (a==0||a==5) 
                score = score + 10;
            else 
                score = score + 5;
        }
    }
}