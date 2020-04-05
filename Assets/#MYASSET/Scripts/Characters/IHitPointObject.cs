using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IHitPointObject
{
    IObservable<Unit> DeadSubject { get; }
    void GetDamage(int value, SkillAttributeType attribute);
}
