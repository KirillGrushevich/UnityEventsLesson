using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    void Start()
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
            {
                Debug.Log("FireAction");
                break;
            }
            case "SkillAction":
            {
                Debug.Log("SkillAction");
                break;
            }
            case "Horizontal":
            {
                Debug.Log($"Horizontal: {context.ReadValue<float>()}");
                break;
            }
            case "MousePosition":
            {
                Debug.Log($"Mouse: {context.ReadValue<Vector2>()}");
                break;
            }
        }
    }
}
