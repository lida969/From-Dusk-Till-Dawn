using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zvuc : MonoBehaviour
{
    private const float TIMER_MAX_TIME = 36f;
    private float timerCurrentTime = TIMER_MAX_TIME;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (timerCurrentTime > 0)
        {

            timerCurrentTime -= Time.deltaTime;
        }
        else
        {
            
        }
    }
}
