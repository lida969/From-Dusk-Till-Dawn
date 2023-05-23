using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 8f;

    public float closeRange = 10f;

    void Update()
    {
        var player = FindObjectOfType<Player>();
        if (player != null && Vector3.Distance(transform.position, player.transform.position) < closeRange)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
