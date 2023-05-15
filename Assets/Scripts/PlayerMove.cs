using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed;
    // С какой скоростью должен двигаться объект

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // Vector3.в какое направление двигаться объекту
    }
}