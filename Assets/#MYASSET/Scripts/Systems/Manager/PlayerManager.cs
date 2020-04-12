using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerManager : ManagerBase<PlayerManager>
{
    public PlayerState PlayerState = new PlayerState();

    private SkillController _SkillController = null;

    private void Awake()
    {
        PlayerState = GetComponent<PlayerState>();
    }

    private void Start()
    {
        _SkillController = GetComponent<SkillController>();

        var input = InputController.Instance;

        input.NormalShotButtonPushed
            .Where(_ => _)
            .Subscribe(_ => _SkillController.PlayAstiveSkill(-1));

        input.Skill1ButtonPushed
            .Where(_ => _)
            .Subscribe(_ => _SkillController.PlayAstiveSkill(0));
    }
}
