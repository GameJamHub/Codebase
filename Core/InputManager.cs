using System.Collections;
using System.Collections.Generic;
using Codebase.Core;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    private PlayerIA m_input = null;
    
    public override void Awake()
    {
        base.Awake();
        m_input = new PlayerIA();
    }

    protected override void Init() {}

    private void OnEnable()
    {
        m_input.Enable();
        m_input.Player.Movement.performed += OnMovementPerformed;
        m_input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void OnDisable()
    {
        m_input.Disable();
        m_input.Player.Movement.performed -= OnMovementPerformed;
        m_input.Player.Movement.canceled -= OnMovementCancelled;
    }

    public void EnableInput()
    {
        m_input.Enable();
        m_input.Player.Movement.performed += OnMovementPerformed;
        m_input.Player.Movement.canceled += OnMovementCancelled;
    }

    public void DisableInputs()
    {
        m_input.Disable();
        m_input.Player.Movement.performed -= OnMovementPerformed;
        m_input.Player.Movement.canceled -= OnMovementCancelled;
    }
    
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        if (m_input == null)
        {
            return;
        }

        Vector2 axisValue = value.ReadValue<Vector2>();
        GameplayEvents.SendOnMovement(axisValue, true);
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        if (m_input == null)
        {
            return;
        }

        Vector2 axisValue = value.ReadValue<Vector2>();
        GameplayEvents.SendOnMovement(axisValue, true);
    }
}
