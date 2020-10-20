using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputController : MonoBehaviour
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
                Debug.Log("Fire action");
                break;
            case "SkillAction":
                Debug.Log("Skill action");
                break;
            case "Horizontal":
                Debug.Log($"Horizontal {context.action.ReadValue<float>()}");
                break;
            case "MousePosition":
                Debug.Log($"Mouse position: {context.action.ReadValue<Vector2>()}");
                break;
        }
    }
}
