using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Pause : MonoBehaviour
{
    public static bool gripPressed = false;
    public GameObject pauseMenuUI;
   
    // Update is called once per frame
   /* void Update()
    {
        if (Input.GetKeyDown(GRIP))
        {
            if (GameLsPaused)
            {
                Resume();
            }
            else
            {
                Pause_();
            }
        }
    }*/
    private void MyInput()
    {
        var device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (device.TryGetFeatureValue(CommonUsages.gripButton, out var gripValue) && gripValue && !gripPressed)
        {
            gripPressed = true;
            Pause_();

        }
        else if (!gripValue)
        {
            gripPressed = false;
            Resume();
        }

    }
    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gripPressed = false;
    }
    void Pause_()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gripPressed = true;
    }


}
