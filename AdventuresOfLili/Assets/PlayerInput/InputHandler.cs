using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoSingleton<InputHandler>
{
    public PlayerInput playerInput;

    public bool GKeyDown;
    public bool GKeyUp;
    public bool IsDashKey;
    public bool IsAttack;
    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }
    
    public float GetMovementAxis()
    {
        float inputVector = playerInput.Player.Move.ReadValue<float>();
        return inputVector;
    }
    private void Update()
    {
        GKeyDown = playerInput.Player.Jump.WasPressedThisFrame();
        GKeyUp = playerInput.Player.Jump.WasReleasedThisFrame();
        IsDashKey = playerInput.Player.Dash.WasPerformedThisFrame();
        IsAttack = playerInput.Player.Attack.WasPressedThisFrame();
    }

}
