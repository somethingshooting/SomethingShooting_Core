using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public abstract class ActiveSkill : MonoBehaviour, ISkill
{
    public abstract string SkillName { get; }
    public abstract SkillAttributeType AttributeType { get; }

    public IReadOnlyReactiveProperty<bool> IsRunning => _IsRunning;
    protected BoolReactiveProperty _IsRunning = new BoolReactiveProperty(false);

    /// <summary> スキルのリキャスト時間 </summary>
    public float RecastTime = 0;
    public float RecastTimeCount { get; protected set; } = 0;

    protected abstract void Init();

    public void PlaySkill()
    {
        _IsRunning.Value = true;
        SkillStart();
    }

    protected abstract void SkillStart();

    protected abstract void SkillUpdate();

    protected virtual void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => RecastTimeCount > 0)
            .Subscribe(_ =>
            {
                RecastTimeCount -= Time.deltaTime;
                if (RecastTimeCount < 0)
                {
                    RecastTimeCount = 0;
                }
            });

        this.UpdateAsObservable()
            .Where(_ => IsRunning.Value)
            .Subscribe(_ => SkillUpdate());

        Init();
    }
}
