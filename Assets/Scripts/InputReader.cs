using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public event Action jumpEvent;
    public event Action dodgeEvent;

    public Vector2 MovementValue { get; private set; }

    private Controls controls;

    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        
        jumpEvent?.Invoke();
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        dodgeEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        
    }
}
