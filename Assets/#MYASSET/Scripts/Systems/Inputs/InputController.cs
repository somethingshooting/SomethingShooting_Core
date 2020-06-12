using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : ManagerBase<InputController>
{
    private InputActionMap _InputActionMap = null;

    public PlayerInput PlayerInput { get; private set; } = null;
    private InputAction _PlayerMoveAction = null;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        _PlayerMoveAction = PlayerInput.currentActionMap.FindAction("PlayerMove");
    }
}