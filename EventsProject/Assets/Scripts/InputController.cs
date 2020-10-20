using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    // Start is called before the first frame update
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
                Debug.Log("Fire");
                break;
            case "SkillAction":
                Debug.Log("Skill");
                break;
            case "Horizontal":
                Debug.Log("Hor " + context.action.ReadValue<float>());
                break;
            case "MousePosition":
                Debug.Log("Mouse " + context.action.ReadValue<Vector2>());
                break;
        }
    }
}
