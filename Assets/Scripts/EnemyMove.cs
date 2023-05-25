using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyMove : MonoBehaviour
{
    public float speed = 8f;

    public float closeRange = 10f;

    void Update()
    {
        var player = FindObjectOfType<Player>();
        if (gameObject!= null && player != null && Vector3.Distance(transform.position, player.transform.position) < closeRange)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (gameObject != null && player != null &&  player.transform.position.x > (transform.position.x+new Vector3(10f, 0f, 0f).x))
        {
            this.gameObject.SetActive(false);
        }
    }
}
