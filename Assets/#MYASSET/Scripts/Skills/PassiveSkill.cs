using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public abstract class PassiveSkill : MonoBehaviour, ISkill
{
    public abstract string SkillName { get; }
    public abstract SkillAttributeType AttributeType { get; }

    protected abstract void Init();

    public void PlaySkill()
    {
        SkillStart();
    }

    protected virtual void SkillStart()
    {

    }

    protected abstract void SkillUpdate();

    protected virtual void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => SkillUpdate());

        Init();
    }
}
