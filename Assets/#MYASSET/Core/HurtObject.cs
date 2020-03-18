using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

[RequireComponent(typeof(Rigidbody))]
public class HurtObject : MonoBehaviour
{
    public int MaxHP;
    [HideInInspector]
    public int CurrentHP;
    public ObjectType type;


    public Subject<int> damagEvent = new Subject<int>();
    public Subject<int> dethEvent = new Subject<int>();

    public IObservable<int> DamageEvent
    {
        get { return damagEvent; }
    }
    public IObservable<int> DethEvent
    {
        get { return dethEvent; }
    }

    public void Start()
    {
        CurrentHP = MaxHP;
    }

    public void GetDamage(int damage)
    {
        CurrentHP -= damage;
        damagEvent.OnNext(damage);
        if (CurrentHP<=0)
        {
            dethEvent.OnNext(damage);
        }
    }

}
public enum ObjectType
{
    Player,Enemy,
}
