using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public abstract class EnemyBehaviour : MonoBehaviour, IHitPointObject
{
    public IObservable<Unit> DeadSubject => _DeadSubject;
    protected Subject<Unit> _DeadSubject; 

    public virtual void GetDamage(int value,SkillAttributeType attribute)
    {
        state.HP.AddValue(-value);
        if (state.HP.Value<=0)
        {
            _DeadSubject.OnNext(Unit.Default);
        }
    }

    private EnemyState state;
    public void Start()
    {
        state = GetComponent<EnemyState>();
    }

}
