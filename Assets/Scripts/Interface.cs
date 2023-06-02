using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interface : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int scoreWeGot;
    private const float TIMER_MAX_TIME = 26f;
    private float timerCurrentTime = TIMER_MAX_TIME;

    private void Awake()
    {
        scoreText = this.GetComponent<TextMeshProUGUI>();
        
    }

    private void Start()
    {
        scoreText.text = " ";
    }

    private void Update()
    {
        if (timerCurrentTime > 0)
        {
            timerCurrentTime -= Time.deltaTime;
        }
        else
        {
            scoreWeGot = EnemyHealth.score;
            scoreText.text = "Score:" + scoreWeGot;
        }
        
    }

}