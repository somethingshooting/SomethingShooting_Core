using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary> プレイヤーが装着しているSkillのSkillDataを持ってるコンポーネント </summary>
public class PlayerCurrentSkillData : MonoBehaviour
{

    public SkillData NormalSkillData => _NormalSkillData;
    [SerializeField] private SkillData _NormalSkillData;

    public List<SkillData> ActiveSkillDatas => _ActiveSkillDatas;
    [SerializeField] private List<SkillData> _ActiveSkillDatas;

    public List<SkillData> PassiveSkillDatas => _PassiveSkillDatas;
    [SerializeField] private List<SkillData> _PassiveSkillDatas;

    public List<SkillData> AllSkillDatas()
    {
        var datas = new List<SkillData>(_ActiveSkillDatas);
        datas.Add(_NormalSkillData);
        foreach (var data in _PassiveSkillDatas)
        {
            if (!datas.Contains(data))
            {
                datas.Add(data);
            }
        }

        return datas;
    }

    public void SetNormalSkill(SkillData data)
    {
        _NormalSkillData = data;
    }

    public void SetActiveSkills(List<SkillData> datas)
    {
        _ActiveSkillDatas = datas;
    }

    public void SetPassiveSkills(List<SkillData> datas)
    {
        _PassiveSkillDatas = datas;
    }
}
