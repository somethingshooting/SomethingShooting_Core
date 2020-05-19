using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

[RequireComponent(typeof(PlayerState), typeof(Collider))]
public class PlayerHitPoint : MonoBehaviour, IHitPointObject
{
    public IObservable<Unit> DeadSubject => _DeadSubject;
    protected Subject<Unit> _DeadSubject = new Subject<Unit>();

    [SerializeField] private float _InvincibleTime = 0.6f;

    private PlayerState _State;
    private Collider _Collider;

    public virtual void GetDamage(int value, SkillAttributeType attribute)
    {
        _State.HP.AddValue(-value);
        if (_State.HP.Value<=0)
        {
            _DeadSubject.OnNext(Unit.Default);
        }
        StartCoroutine(InvincibleCollider());
    }

    private void Start()
    {
        _State = GetComponent<PlayerState>();
        _Collider = GetComponent<Collider>();

        DeadSubject
            .Subscribe(_ => SceneManager.Instance.ChangeScene("_GameOver"));
    }
    IEnumerator InvincibleCollider()
    {
        _Collider.enabled = false;
        yield return new WaitForSeconds(_InvincibleTime);
        _Collider.enabled = true;
    }
}
