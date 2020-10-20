using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private void Start()
    {
        var playerInput = GetComponent<PlayerInput>();
        playerInput.onActionTriggered += OnInputAction;
    }

    private void OnInputAction(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        switch (context.action.name)
        {
            case "FireAction":
                Debug.Log("Fire Action");
                break;
            case "SkillAction":
                Debug.Log("Skill Action");
                break;
            case "Horizontal":
                Debug.Log($"Horizontal {context.ReadValue<float>()}");
                break;
            case "MousePosition":
                Debug.Log($"Mouse position {context.ReadValue<Vector2>()}");
                break;
        }
    }
}
