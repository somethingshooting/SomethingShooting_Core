using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_InstantiateBullet : ActiveSkill
{
    [SerializeField] private GameObject _Bullet;

    protected override void Init()
    {

    }

    protected override void SkillStart()
    {
       var obj =  Instantiate(_Bullet);
        obj.transform.position = transform.position;
    }

    protected override void SkillUpdate()
    {

    }
}
