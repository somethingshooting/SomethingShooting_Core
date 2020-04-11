using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UniRx;

public class SkillController : MonoBehaviour
{
    private InputController InputController;

    public IActiveSkill NormalShotSkill { get; protected set; }

    public IReadOnlyList<IActiveSkill> ActiveSkills => _ActiveSkills;
    private List<IActiveSkill> _ActiveSkills;

    public IReadOnlyList<IPassiveSkill> PassiveSkills => _PassiveSkills;
    private List<IPassiveSkill> _PassiveSkills;

    private void Start()
    {
        InputController = InputController.Instance;

        InputController.NormalShotButtonPushed
            .Where(_ => _)
            .Subscribe(_ => PlayAstiveSkill(-1));

        InputController.Skill1ButtonPushed
            .Where(_ => _)
            .Subscribe(_ => PlayAstiveSkill(0));

        PlayPassiveSills();
    }

    private void Update()
    {
        // 取得済みスキルのUpdateを実行
        if (NormalShotSkill.IsRunning.Value)
        {
            NormalShotSkill.SkillPlayUpdate();
        }

        foreach (var skill in ActiveSkills)
        {
            if (skill.IsRunning.Value)
            {
                skill.SkillPlayUpdate();
            }
        }

        foreach (var skill in PassiveSkills)
        {
            if (skill.IsRunning.Value)
            {
                skill.SkillPlayUpdate();
            }
        }
    }

    public void SetSkill(IActiveSkill skill)
    {
        _ActiveSkills.Add(skill);
    }

    public void SetSkill(IPassiveSkill skill)
    {
        _PassiveSkills.Add(skill);
    }

    private void PlayAstiveSkill(int num)
    {
        var playable = true;

        if (NormalShotSkill.IsRunning.Value)
            playable =  false;

        foreach (var activeSkill in ActiveSkills)
        {
            if (activeSkill.IsRunning.Value)
                playable = false;
        }

        if (playable)
        {
            if (num == -1)
                NormalShotSkill.SkillPlayStart();
            else
                ActiveSkills[num].SkillPlayStart();
        }

    }

    private void PlayPassiveSills()
    {
        foreach (var passiveSkill in PassiveSkills)
        {
            if (!passiveSkill.IsRunning.Value)
            {
                passiveSkill.Start();
            }
        }
    }
}
