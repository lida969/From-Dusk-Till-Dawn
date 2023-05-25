using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float _currentTimer;
    private double c;
    public static int score;
    //[SerializeField] GameObject enemy;

    void Start()
    {
        score = 0;
        //enemy = GetComponent<Collider>();
    }


    void Update()
    {
        _currentTimer += Time.deltaTime;

        void OnCollisionEnter(Collision collision)
        {
            if (collision. gameObject.CompareTag("Bullet"))
            {
                score += 5;
                if ((_currentTimer > 14f && _currentTimer < 45f)||(_currentTimer > 74f && _currentTimer < 89f)||(_currentTimer > 118f && _currentTimer < 163f) || (_currentTimer > 192f && _currentTimer < 207f))
                {
                    c = _currentTimer / 0.1;
                    if (c % 10 == 0)
                        score += 5;
                }
                else
                    score += 5;
            }
        }
    }
}