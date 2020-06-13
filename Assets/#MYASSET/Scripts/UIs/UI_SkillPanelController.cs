using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkillPanelController : MonoBehaviour
{

    private PlayerJobController _JobController = null;
    private SkillController _SkillController = null;
    private List<UI_SkillButtonController> _SkillButtons = new List<UI_SkillButtonController>();

    void Start()
    {

    }

    private void OnEnable()
    {
        if (_JobController == null)
        {
            _JobController = GameObject.FindWithTag("Player").GetComponent<PlayerJobController>();
        }

        if (_SkillController == null)
        {
            _SkillController = GameObject.FindWithTag("Player").GetComponent<SkillController>();
        }

        var acquirableSkillList = new Dictionary<string, SkillData>(); // 取得可能なスキルのリスト

        foreach (var job in _JobController.CurrentJobs)
        {
            foreach (var skill in job.GivenSkill)
            {
                if (!acquirableSkillList.ContainsKey(skill.SkillName))
                {
                    acquirableSkillList.Add(skill.SkillName, skill);
                }
            }
        }

        #region 既存スキルを除外
        acquirableSkillList.Remove(_SkillController.NormalShotSkill.SkillName);
        foreach (var askill in _SkillController.ActiveSkills)
        {
            acquirableSkillList.Remove(askill.SkillName);
        }
        foreach (var pskill in _SkillController.PassiveSkills)
        {
            acquirableSkillList.Remove(pskill.SkillName);
        }
        #endregion


    }
}
