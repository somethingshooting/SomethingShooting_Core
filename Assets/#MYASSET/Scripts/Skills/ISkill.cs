using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    string SkillName { get; }

    SkillAttributeType AttributeType { get; }

    void PlaySkill();
}
