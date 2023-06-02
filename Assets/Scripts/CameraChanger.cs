using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChanger : MonoBehaviour
{
    private const float TIMER_MAX_TIME = 26f;
    private float timerCurrentTime = TIMER_MAX_TIME;

    private void Update()
    {
        if (timerCurrentTime > 0)
        {
            timerCurrentTime -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

}
