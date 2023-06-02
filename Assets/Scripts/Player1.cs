using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1 : MonoBehaviour
{
    private const string GRIP = "Grip";
    

    [SerializeField] private InputActionProperty _gripAction;
  

    private void Update()
    {
        var gripValue = _gripAction.action.ReadValue<float>();
        

        gripValue = gripValue < 0f ? 0f : gripValue;

        

    }
}

