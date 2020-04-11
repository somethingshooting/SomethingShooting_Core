using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public abstract class PassiveSkill : MonoBehaviour, IPassiveSkill
{
    public string SkillName { get; }
    public SkillAttributeType AttributeType { get; }

    public IReadOnlyReactiveProperty<bool> IsRunning => _IsRunning;
    protected BoolReactiveProperty _IsRunning = new BoolReactiveProperty(false);

    protected abstract void Init();

    protected abstract void SkillUpdate();

    public virtual void Start()
    {
        _IsRunning.Value = true;
        Init();
    }

    public virtual void SkillPlayUpdate()
    {
        SkillUpdate();
    }
}
