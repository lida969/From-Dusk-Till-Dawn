using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotomenu : MonoBehaviour
{
    public void MenuBtn()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
