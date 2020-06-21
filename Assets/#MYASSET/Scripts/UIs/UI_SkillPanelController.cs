using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

public class UI_SkillPanelController : MonoBehaviour
{
    public IReadOnlyReactiveProperty<SelectSkillPattern> SelectPattern => _SelectPattern;
    private ReactiveProperty<SelectSkillPattern> _SelectPattern = new ReactiveProperty<SelectSkillPattern>(SelectSkillPattern.Normal);

    public IReadOnlyReactiveProperty<SkillData> CurrentSkillData => _CurrentSkillData;
    private ReactiveProperty<SkillData> _CurrentSkillData = new ReactiveProperty<SkillData>();
    public IReadOnlyReactiveProperty<SkillData> SelectSkillData => _SelectSkillData;
    private ReactiveProperty<SkillData> _SelectSkillData = new ReactiveProperty<SkillData>();

    private PlayerJobController _JobController = null;
    private SkillController _SkillController = null;
    private UI_SkillSelectButtonBuilder _ButtonBuilder = null;
    private PlayerCurrentSkillData _PlayerCurrentData = null;

    /// <summary> 未装着のJobから見た取得しうるスキル </summary>
    private List<SkillData> _SelectableSkillDatas = new List<SkillData>();

    private List<SkillData> _NormalSkills = new List<SkillData>();
    private List<SkillData> _ActiveSkills = new List<SkillData>();
    private List<SkillData> _PassiveSkills = new List<SkillData>();

    private void Start()
    {
        SelectPattern
            .Subscribe(_ => ChangeViewButtonsPattern());
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

        if (_PlayerCurrentData == null)
        {
            _PlayerCurrentData = GameObject.FindWithTag("Player").GetComponent<PlayerCurrentSkillData>();
        }

        UpdateSkillDatas();
    }

    private void UpdateSkillDatas()
    {
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

        _SelectableSkillDatas = new List<SkillData>(acquirableSkillList.Values);

        // 取得可能スキル - 装着済みスキル
        _SelectableSkillDatas.Except(_PlayerCurrentData.AllSkillDatas());

        _NormalSkills = _SelectableSkillDatas.FindAll(data => data.Skilltype == SkillData.SkillType.normal);
        _ActiveSkills = _SelectableSkillDatas.FindAll(data => data.Skilltype == SkillData.SkillType.active);
        _PassiveSkills = _SelectableSkillDatas.FindAll(data => data.Skilltype == SkillData.SkillType.passive);
        Debug.Log("スキル情報をアップデートしました。");
    }

    private void ChangeViewButtonsPattern()
    {
        _SelectSkillData.Value = null;
        _CurrentSkillData.Value = null;

        switch (SelectPattern.Value)
        {
            case SelectSkillPattern.Normal:
                _ButtonBuilder.ChangeActiveSkillPatternSelect(_NormalSkills);
                _ButtonBuilder.ChangeActiveSkillPattern(_PlayerCurrentData.NormalSkillData);
                break;
            case SelectSkillPattern.Active:
                _ButtonBuilder.ChangeActiveSkillPatternSelect(_ActiveSkills);
                _ButtonBuilder.ChangeActiveSkillPatternCurrent(_PlayerCurrentData.ActiveSkillDatas);
                break;
            case SelectSkillPattern.Passive:
                _ButtonBuilder.ChangeActiveSkillPatternSelect(_PassiveSkills);
                _ButtonBuilder.ChangeActiveSkillPatternCurrent(_PlayerCurrentData.PassiveSkillDatas);
                break;
        }
        Debug.Log("スキルの見た目情報をアップデートしました。");
    }

    public void ChangePattern(SelectSkillPattern pattern)
    {
        _SelectPattern.Value = pattern;
    }

    public void OnSelectOrCurrentButtonDown(bool isSelect, SkillData data)
    {
        if (data == null)
        {
            Debug.LogError("引数で渡されたdataがnullです");
            return;
        }

        if (isSelect)
        {
            if (_SelectSkillData.Value == null)
            {
                Debug.Log("選択欄のデータを空の状態のデータから" + data.SkillName + "へと変更します。");
            }
            else
            {
                Debug.Log("選択欄のデータを" + _SelectSkillData.Value.SkillName + "から" + data.SkillName + "へと変更します。");
            }
            _SelectSkillData.Value = data;
        }
        else
        {
            if (_CurrentSkillData.Value == null)
            {
                Debug.Log("選択欄のデータを空状態のデータから" + data.SkillName + "へと変更します。");
            }
            else
            {
                Debug.Log("選択欄のデータを" + _CurrentSkillData.Value.SkillName + "から" + data.SkillName + "へと変更します。");
            }
            _CurrentSkillData.Value = data;
        }
    }

    public void OnSuccess()
    {
        if (SelectSkillData != null && CurrentSkillData != null)
        {
            List<SkillData> list;
            switch (SelectPattern.Value)
            {
                case SelectSkillPattern.Normal:
                    _PlayerCurrentData.SetNormalSkill(_CurrentSkillData.Value);
                    break;
                case SelectSkillPattern.Active:
                    list = new List<SkillData>(_PlayerCurrentData.ActiveSkillDatas);
                    list[list.IndexOf(_CurrentSkillData.Value)] = _SelectSkillData.Value;

                    _PlayerCurrentData.SetActiveSkills(list);
                    break;
                case SelectSkillPattern.Passive:
                    list = new List<SkillData>(_PlayerCurrentData.PassiveSkillDatas);
                    Debug.Log("Skill " + list[list.IndexOf(_CurrentSkillData.Value)].SkillName + "を Skill " + _SelectSkillData.Value.SkillName + "へ変更します。");
                    list[list.IndexOf(_CurrentSkillData.Value)] = _SelectSkillData.Value;

                    _PlayerCurrentData.SetPassiveSkills(list);
                    break;
            }
            UpdateSkillDatas();
            ChangeViewButtonsPattern();
        }
    }

    public enum SelectSkillPattern
    {
        None = 0,
        Normal = 1,
        Active = 2,
        Passive = 3,
    }
}
