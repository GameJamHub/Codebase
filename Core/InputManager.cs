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
        EnableInput();
    }

    private void OnDisable()
    {
        m_input.Disable();
        DisableInputs();
    }

    public void EnableInput()
    {
        m_input.Enable();
        m_input.Player.Movement.performed += OnMovementPerformed;
        m_input.Player.Movement.canceled += OnMovementCancelled;
        m_input.Player.Jump.performed += OnJumpPerformed;
        m_input.Player.ShortRange.performed += OnShortAttackPerformed;
        m_input.Player.LongRange.performed += OnLongAttackPerformed;
    }

    public void DisableInputs()
    {
        m_input.Disable();
        m_input.Player.Movement.performed -= OnMovementPerformed;
        m_input.Player.Movement.canceled -= OnMovementCancelled;
        m_input.Player.Jump.performed -= OnJumpPerformed;
        m_input.Player.ShortRange.performed -= OnShortAttackPerformed;
        m_input.Player.LongRange.performed -= OnLongAttackPerformed;
    }

    private void OnJumpPerformed(InputAction.CallbackContext value)
    {
        GameplayEvents.SendOnJump();
    }

    private void OnShortAttackPerformed(InputAction.CallbackContext value)
    {
        GameplayEvents.SendOnShortAttackPerformed();
    }

    private void OnLongAttackPerformed(InputAction.CallbackContext value)
    {
        GameplayEvents.SendOnLongAttackPerformed();
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
        GameplayEvents.SendOnMovement(axisValue, false);
    }
}
