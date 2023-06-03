using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cube : MonoBehaviour
{
    private const float TIMER_MAX_TIME = 34f;
    private float timerCurrentTime = TIMER_MAX_TIME;
    private TextMesh scoreTXT;
    private float score;
    void Start()
    {
        scoreTXT = GetComponent<TextMesh>();
    }

    void Update()
    {
        if (timerCurrentTime > 0)
        {
            score = timerCurrentTime;
            scoreTXT.text = "START IN: " + score;
            timerCurrentTime -= Time.deltaTime;
        }
        else
        {
           Destroy(gameObject);
        }
    }
}
