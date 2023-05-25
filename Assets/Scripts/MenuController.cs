using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene("game");
    }

    

    /*public void Back()
    {
        SceneManager.LoadScene("mainMenu");
    }*/

    /*public void ExitPressed()
    {
        Application.Quit();
    }*/
}
