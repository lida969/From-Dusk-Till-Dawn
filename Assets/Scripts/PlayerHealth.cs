using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Transform menuPoint;
    [SerializeField] GameObject lefth;
    [SerializeField] GameObject leftr;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EN_Bullet"))
        {
            transform.position = menuPoint.position;
            GetComponent<PlayerMove>().enabled = false;
            lefth.GetComponent<ShootingLeftHand>().enabled = false;
            leftr.GetComponent<ShootingRightHand>().enabled = false;
            //this.transform.position = new Vector3(18f, -46.792f, 641.9f);
        }
    }
}
