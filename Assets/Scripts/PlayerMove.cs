using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 8f;
    
   
    private const float TIMER_MAX_TIME = 35f;
    private float timerCurrentTime = TIMER_MAX_TIME; 

    void Update()
    {
        if (timerCurrentTime > 0)
        {
            timerCurrentTime -= Time.deltaTime; 
        }
        else
        {
           
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            


        }

        

    }
   
}