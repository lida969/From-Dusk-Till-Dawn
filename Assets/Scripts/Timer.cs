using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private const float TIMER_MAX_TIME = 34f;
    private float timerCurrentTime = TIMER_MAX_TIME;

    

    void Update()
    {
        if (timerCurrentTime > 0)
        {
            
            timerCurrentTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
