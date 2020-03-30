using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface ISkill
{
    string SkillName { get; }

    SkillAttributeType AttributeType { get; }

    IReadOnlyReactiveProperty<bool> IsRunning { get; }

    void SkillInit();
}
