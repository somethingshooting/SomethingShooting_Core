using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveSkill : MonoBehaviour, ISkill
{
    public abstract string SkillName { get; }
    public abstract SkillAttributeType AttributeType { get; }

    protected abstract void Init();

    public abstract void SkillStart();

    protected virtual void Start()
    {
        Init();
    }
}
