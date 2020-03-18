using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public abstract class PassiveSkill : MonoBehaviour, ISkill
{
    public abstract string SkillName { get; }
    public abstract SkillAttributeType AttributeType { get; }

    protected bool _IsRunning = false;

    public void PlaySkill()
    {
        SkillStart();
    }

    protected virtual void SkillStart()
    {
        _IsRunning = true;
        this.UpdateAsObservable()
            .Where(_ => _IsRunning)
            .Subscribe(_ => SkillUpdate());
    }

    protected abstract void SkillUpdate();
}
