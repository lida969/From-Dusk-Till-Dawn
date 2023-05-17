using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    public float HP = 1;

    public void AddDamage(float damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}