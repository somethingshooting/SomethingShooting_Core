using System.Collections;
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
    public float RecastTime = 3;
    public float RecastTimeCount { get; protected set; } = 0;

    /// <summary>
    /// スキルのリキャストタイマーの補正値
    /// </summary>
    public Parameter<int> RecastTimeCorrection = new Parameter<int>(1);

    /// <summary>
    /// スキルの全体硬直時間
    /// </summary>
    [SerializeField] protected float SkillTime = 2;

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

        this.UpdateAsObservable()
            .Where(_ => IsRunning.Value)
            .Subscribe(_ => SkillPlayUpdate());


        Init();

        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                if (RecastTimeCount > 0)
                {
                    RecastTimeCount -= Time.deltaTime;
                    if (RecastTimeCount < 0)
                    {
                        RecastTimeCount = 0;
                    }
                }
            });
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
        SkillStart();
        _IsRunning.Value = true;
    }

    public virtual void SkillPlayUpdate()
    {
        // RecastTimeCount > 0 の時に実行される処理
        if (SkillTimeCount >= 0)
        {
            SkillTimeCount -= Time.deltaTime;
            if (SkillTimeCount < 0)
            {
                SkillTimeCount = 0;
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

    public virtual bool PlayableSkill()
    {
        if (RecastTimeCount > 0)
        {
            Debug.Log("スキルがリキャスト中です 残り時間 : " + RecastTimeCount);
            return false;
        }
        return true;
    }
}
