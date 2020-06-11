using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_InstantiateWhileGoAround : ActiveSkill
{
    [SerializeField] private GameObject _BulletObj = null;

    [SerializeField] private float _InstantiateInterval = 0.4f;
    private float _IntervalTimer = 0;

    [SerializeField] private bool _Clockwise = false;
    [SerializeField, Range(0, 360)] private float _StartAngle = 0;
    [SerializeField] private float _EndAngle = 0;

    private float[] _Angles = new float[0];
    private int _MaxShootValue = 0;
    private int _CurrentShooted = 0;

    protected override void Init()
    {
        _MaxShootValue = (int)(SkillTime / _InstantiateInterval);
        _Angles = new float[_MaxShootValue];
    }

    protected override void SkillStart()
    {
        _CurrentShooted = 0;
        for (int i = 0; i < _Angles.Length; i++)
        {
            _Angles[i] = (_EndAngle / SkillTime) * _InstantiateInterval * i;
        }
    }

    protected override void SkillUpdate()
    {
        _IntervalTimer += Time.deltaTime;
        if (_IntervalTimer >= _InstantiateInterval)
        {
            InstantiateBullet();
            _IntervalTimer = 0;
        }
    }

    private void InstantiateBullet()
    {
        var obj = Instantiate(_BulletObj);
        obj.transform.position = gameObject.transform.position;
        obj.transform.rotation = Quaternion.AngleAxis(_Angles[_CurrentShooted] + 90, Vector3.up);
        _CurrentShooted++;
    }
}
