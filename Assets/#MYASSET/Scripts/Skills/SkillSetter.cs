using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkillController))]
public class SkillSetter : MonoBehaviour
{
    private SkillController SkillController = null;

    [SerializeField] private MonoBehaviour _NormalSkill;

    [SerializeField] private List<MonoBehaviour> _ActiveSkills;

    [SerializeField] private List<MonoBehaviour> _PassiveSkills;

    void Start()
    {
        SkillController = GetComponent<SkillController>();

        if (_NormalSkill is IActiveSkill)
        {
            SkillController.SetNormalSkill((IActiveSkill)_NormalSkill);
        }

        foreach (var active in _ActiveSkills)
        {
            if (active is IActiveSkill)
            {
                SkillController.SetSkill((IActiveSkill)active);
            }
        }

        foreach (var passive in _PassiveSkills)
        {
            if (passive is IPassiveSkill)
            {
                SkillController.SetSkill((IPassiveSkill)passive);
            }
        }
    }
}
