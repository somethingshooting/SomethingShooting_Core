using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UI_SkillPanelController : MonoBehaviour
{
    public IReadOnlyReactiveProperty<SelectSkillPattern> SelectPattern => _SelectPattern;
    private ReactiveProperty<SelectSkillPattern> _SelectPattern = new ReactiveProperty<SelectSkillPattern>(SelectSkillPattern.Normal);

    private PlayerJobController _JobController = null;
    private SkillController _SkillController = null;
    private UI_SkillSelectButtonBuilder _ButtonBuilder = null;
    private List<UI_SkillButtonController> _SkillButtons = new List<UI_SkillButtonController>();

    [SerializeField] private List<SkillData> SkillDatas = new List<SkillData>();

    private void Start()
    {
        SelectPattern.Subscribe(_ => ChangeViewButtonsPattern());
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

        if (_ButtonBuilder == null)
        {
            _ButtonBuilder = GetComponent<UI_SkillSelectButtonBuilder>();
        }

        var acquirableSkillList = new Dictionary<string, SkillData>(); // 取得可能なスキルのリスト

        // JobControllerから取得可能なSkillをすべて入れる
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
        if (_SkillController.NormalShotSkill != null)
        {
            acquirableSkillList.Remove(_SkillController.NormalShotSkill.SkillName);
        }
        foreach (var askill in _SkillController.ActiveSkills)
        {
            acquirableSkillList.Remove(askill.SkillName);
        }
        foreach (var pskill in _SkillController.PassiveSkills)
        {
            acquirableSkillList.Remove(pskill.SkillName);
        }
        #endregion

        // 取得していない、取得可能スキル
        SkillDatas = new List<SkillData>(acquirableSkillList.Values);

        // Skill選択のButtonを生成
        for (int i = 0; i < acquirableSkillList.Count; i++)
        {
            _ButtonBuilder.InstanceNewButton(true);
        }
    }

    private void ChangeViewButtonsPattern()
    {
        Debug.Log("ボタンの表示を" + SelectPattern.Value + "へ切り替えます");
    }

    public void ChangePattern(SelectSkillPattern pattern)
    {
        _SelectPattern.Value = pattern;
    }

    public enum SelectSkillPattern
    {
        None = 0,
        Normal = 1,
        Active = 2,
        Passive = 3,
    }
}
