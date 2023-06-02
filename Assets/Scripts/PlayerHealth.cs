using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EN_Bullet"))
        {
            
            SceneManager.LoadScene("mainMenu 1");
        }
    }
}
