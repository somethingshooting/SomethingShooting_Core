using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_InstattiateMultipleBullet : ActiveSkill
{
    [SerializeField] private BulletData[] _Bullets;
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
        for (int i = 0; i < _Bullets.Length; i++)
        {
            var obj = Instantiate(_Bullets[i].Obj);
            obj.transform.position = _ShotTransform.position;
            obj.transform.rotation = Quaternion.Euler(_Bullets[i].Rotation);
        }
    }

    protected override void SkillUpdate()
    {

    }

    [Serializable]
    public class BulletData
    {
        public GameObject Obj;
        public Vector3 Rotation;
    }
}
