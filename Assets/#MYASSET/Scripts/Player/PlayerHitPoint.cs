using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class PlayerHitPoint : MonoBehaviour,IHitPointObject
{
    public IObservable<Unit> DeadSubject => _DeadSubject;
    protected Subject<Unit> _DeadSubject;

    public virtual void GetDamage(int value, SkillAttributeType attribute)
    {
        _State.HP.AddValue(-value);
        if (_State.HP.Value<=0)
        {
            _DeadSubject.OnNext(Unit.Default);
        }
    }

    private PlayerState _State;
    private void Start()
    {
        _State = GetComponent<PlayerState>();
    }
}
