using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActiveSkill : ISkill
{
    void SkillPlayStart();

    void SkillPlayUpdate();
}
