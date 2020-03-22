using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testactiveskill : ActiveSkill
{
    public override string SkillName { get; }

    public override SkillAttributeType AttributeType { get; }

    protected override void Init()
    {
    }

    protected override void SkillStart()
    {
        Debug.Log("つよい");
    }

    protected override void SkillUpdate()
    {
    }
}
