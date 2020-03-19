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

    /// <summary>
    /// スキルのリキャストタイマーの補正値
    /// </summary>
    public Parameter RecastTimeCorrection = new Parameter(1);

    /// <summary>
    /// スキルの全体硬直時間
    /// </summary>
    [SerializeField] protected float SkillTime = 10;

    protected float SkillTimeCount = 0;

    /// <summary>
    /// シーン開始時に一度だけ呼ばれる
    /// </summary>
    protected abstract void Init();

    public void PlaySkill()
    {
        _IsRunning.Value = true;
        SkillStart();
    }

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
    protected virtual void SkillEnd()
    {

    }

    protected virtual void Start()
    {
        // IsRunning == ture になった時に実行される処理
        IsRunning
            .Where(_ => _)
            .Subscribe(_ =>
            {
                RecastTimeCount = RecastTime;
                SkillTimeCount = SkillTime;
            });

        // RecastTimeCount > 0 の時に実行される処理
        this.UpdateAsObservable()
            .Where(_ => RecastTimeCount > 0)
            .Subscribe(_ =>
            {
                RecastTimeCount -= Time.deltaTime * RecastTimeCorrection.Value;
                if (RecastTimeCount < 0)
                {
                    RecastTimeCount = 0;
                }
            });

        // IsRunning == ture の時に実行される処理
        this.UpdateAsObservable()
            .Where(_ => IsRunning.Value)
            .Subscribe(_ => SkillUpdate());

        // SkillTimeCOunt > 0 の時に実行される処理
        this.UpdateAsObservable()
            .Where(_ => SkillTimeCount > 0)
            .Subscribe(_ =>
            {
                SkillTimeCount -= Time.deltaTime;
                if (SkillTimeCount < 0)
                {
                    SkillEnd();
                    _IsRunning.Value = false;
                }
            });

        // IsRunning == false になったときに実行される処理
        IsRunning
            .SkipLatestValueOnSubscribe()
            .Where(_ => !_)
            .Subscribe(_ => SkillEnd());

        Init();
    }
}
