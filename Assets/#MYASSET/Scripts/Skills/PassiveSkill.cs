using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public abstract class PassiveSkill : MonoBehaviour, ISkill
{
    public abstract string SkillName { get; }
    public abstract SkillAttributeType AttributeType { get; }

    public IReadOnlyReactiveProperty<bool> IsRunning => _IsRunning;
    protected BoolReactiveProperty _IsRunning = new BoolReactiveProperty(false);

    protected abstract void Init();

    public void PlaySkill()
    {
        _IsRunning.Value = true;
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
