﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public abstract class ActiveSkill : MonoBehaviour, IActiveSkill
{
    public string SkillName => _SkillName;
    [SerializeField] protected string _SkillName;

    public SkillAttributeType AttributeType => _AttributeType;
    [SerializeField] protected SkillAttributeType _AttributeType = SkillAttributeType.None;

    public IReadOnlyReactiveProperty<bool> IsRunning => _IsRunning;
    protected BoolReactiveProperty _IsRunning = new BoolReactiveProperty(false);

    /// <summary> スキルのリキャスト時間 </summary>
    public float RecastTime = 0;
    public float RecastTimeCount { get; protected set; } = 0;

    /// <summary>
    /// スキルのリキャストタイマーの補正値
    /// </summary>
    public Parameter<int> RecastTimeCorrection = new Parameter<int>(1);

    /// <summary>
    /// スキルの全体硬直時間
    /// </summary>
    [SerializeField] protected float SkillTime = 10;

    protected float SkillTimeCount = 0;

    public virtual void Start()
    {
        // IsRunning == ture になった時に実行される処理
        IsRunning
            .Where(_ => _)
            .Subscribe(_ =>
            {
                RecastTimeCount = RecastTime;
                SkillTimeCount = SkillTime;
            });

        // IsRunning == false になったときに実行される処理
        IsRunning
            .SkipLatestValueOnSubscribe()
            .Where(_ => !_)
            .Subscribe(_ => SkillEnd());

        Init();
    }

    /// <summary>
    /// シーン開始時に一度だけ呼ばれる
    /// </summary>
    protected abstract void Init();

    /// <summary>
    /// スキル実行開始時に一度だけ呼ばれる
    /// </summary>
    protected abstract void SkillStart();

    /// <summary>
    /// スキル実行中に毎回呼ばれる
    /// </summary>
    protected abstract void SkillUpdate();

    /// <summary>
    /// スキル実行終了時に一度だけ呼ばれる
    /// </summary>
    protected virtual void SkillEnd() { }

    public virtual void SkillPlayStart()
    {
        _IsRunning.Value = true;
        SkillStart();
    }

    public virtual void SkillPlayUpdate()
    {
        // RecastTimeCount > 0 の時に実行される処理
        if (RecastTimeCount > 0)
        {
            RecastTimeCount -= Time.deltaTime * RecastTimeCorrection.Value;
            if (RecastTimeCount < 0)
            {
                RecastTimeCount = 0;
                SkillEnd();
                _IsRunning.Value = false;
            }
        }

        // IsRunning == ture の時に実行される処理
        if (IsRunning.Value)
        {
            SkillUpdate();
        }
    }
}
