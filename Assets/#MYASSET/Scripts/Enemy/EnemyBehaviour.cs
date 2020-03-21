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

    }
}
