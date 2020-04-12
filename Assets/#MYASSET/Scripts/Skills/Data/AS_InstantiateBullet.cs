using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_InstantiateBullet : ActiveSkill
{
    [SerializeField] private GameObject _Bullet;
    [SerializeField] private Transform _ShotTransform;
    protected override void Init()
    {
        if (_ShotTransform == null)
        {
            _ShotTransform = transform;
        }
    }

    protected override void SkillStart()
    {
       var obj =  Instantiate(_Bullet);
        obj.transform.position = _ShotTransform.position;
    }

    protected override void SkillUpdate()
    {

    }
}
