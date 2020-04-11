using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AS_Instance : ActiveSkill
{
    [SerializeField] private GameObject _Bullet;

    protected override void Init()
    {

    }

    protected override void SkillStart()
    {
        Instantiate(_Bullet);
    }

    protected override void SkillUpdate()
    {

    }
}
