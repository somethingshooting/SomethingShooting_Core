using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public abstract class PassiveSkill : ScriptableObject, IPassiveSkill
{
    public abstract string SkillName { get; }
    public abstract SkillAttributeType AttributeType { get; }

    public IReadOnlyReactiveProperty<bool> IsRunning => _IsRunning;
    protected BoolReactiveProperty _IsRunning = new BoolReactiveProperty(false);

    protected abstract void Init();

    protected abstract void SkillUpdate();

    public virtual void SkillInit()
    {
        _IsRunning.Value = true;
        Init();
    }

    public virtual void SkillPlayUpdate()
    {
        SkillUpdate();
    }
}
