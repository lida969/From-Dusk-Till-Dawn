using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // The object's movement speed
    public float speed = 8f;

    // The time in seconds after which the object will start moving
    //public float startTime = 15f;

    private const float TIMER_MAX_TIME = 15f; //����� �������
    private float timerCurrentTime = TIMER_MAX_TIME; //���������� ����������

    void Update()
    {
        if (timerCurrentTime > 0)
        {
            timerCurrentTime -= Time.deltaTime; //��������� ���������� ����������
        }
        else
        {
           
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
             
        }
    }
   /* void Start()
    {
        // Start a timer to move the object after the specified time
        StartCoroutine(MoveObject());
    }*/

    /*IEnumerator MoveObject()
    {
        yield return new WaitForSeconds(startTime);

        // Move the object along a straight line from its starting position to its ending position
        
        transform.position += transform.right * speed * Time.deltaTime;
        
    }*/
}