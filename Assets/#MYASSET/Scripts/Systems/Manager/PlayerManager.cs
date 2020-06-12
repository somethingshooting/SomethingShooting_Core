using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;

public class PlayerManager : ManagerBase<PlayerManager>
{
    public PlayerState PlayerState = new PlayerState();

    private SkillController _SkillController = null;

    private PlayerInput _PlayerInput = null;

    private void Awake()
    {
        PlayerState = GetComponent<PlayerState>();
    }

    private void Start()
    {
        _SkillController = GetComponent<SkillController>();

        _PlayerInput = InputController.Instance.PlayerInput;
    }

    private void Update()
    {
        if (_PlayerInput.actions["NormalSkill"].ReadValue<float>() > 0)
        {
            _SkillController.PlayAstiveSkill(-1);
        }

        if (_PlayerInput.actions["ActiveSkill_1"].ReadValue<float>() > 0)
        {
            _SkillController.PlayAstiveSkill(0);
        }
    }
}
