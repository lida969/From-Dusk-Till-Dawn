using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            this.transform.position = new Vector3(18f, -46.792f, 641.9f);
            GetComponent<PlayerMove>().enabled = false;
            //this.transform.position = new Vector3(18f, -46.792f, 641.9f);
        }
    }
}
