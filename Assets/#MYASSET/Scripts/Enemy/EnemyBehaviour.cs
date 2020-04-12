using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[RequireComponent(typeof( EnemyState))]
public abstract class EnemyBehaviour : MonoBehaviour, IHitPointObject
{
    public IObservable<Unit> DeadSubject => _DeadSubject = new Subject<Unit>();
    protected Subject<Unit> _DeadSubject;

    public EnemyState _State { get; protected set; } = null;

    public virtual void GetDamage(int value,SkillAttributeType attribute)
    {
        _State.HP.AddValue(-value);
        if (_State.HP.Value<=0)
        {
            _DeadSubject.OnNext(Unit.Default);
        }
    }

    protected virtual void Start()
    {
        _State = GetComponent<EnemyState>();

        Init();
    }

    protected abstract void Init();
}
