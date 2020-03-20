using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SkillController : MonoBehaviour
{
    private IInputProvider InputProvider;

    public ActiveSkill NormalShotSkill { get; set; }

    public List<ActiveSkill> ActiveSkills { get;  set; }

    public List<PassiveSkill> PassiveSkills { get; set; }

    void Start()
    {
        InputProvider = GameObject.FindGameObjectWithTag("GameManager").GetComponent<IInputProvider>();

        InputProvider.NormalShotButtonPushed
            .Where(_ => _)
            .Subscribe(_ => PlayAstiveSkill(-1));

        InputProvider.Skill1ButtonPushed
            .Where(_ => _)
            .Subscribe(_ => PlayAstiveSkill(0));

        PlayPassiveSills();
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
                NormalShotSkill.PlaySkill();
            else
                ActiveSkills[num].PlaySkill();
        }

    }

    private void PlayPassiveSills()
    {
        foreach (var passiveSkill in PassiveSkills)
        {
            if (!passiveSkill.IsRunning.Value)
            {
                passiveSkill.PlaySkill();
            }
        }
    }
}
