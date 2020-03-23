using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleNormalBullet : ActiveSkill
{
    public override string SkillName => _SkillName;
    [SerializeField] private string _SkillName = "SimpleNormalBullet";

    public override SkillAttributeType AttributeType => _AttributeType;
    [SerializeField] private SkillAttributeType _AttributeType = SkillAttributeType.None;

    [SerializeField] private GameObject _Bullet = null;

    protected override void Init()
    {

    }

    protected override void SkillStart()
    {
        var bullet = Instantiate(_Bullet, GameObject.FindWithTag("BulletParent").transform);
        bullet.transform.position = transform.position;
    }

    protected override void SkillUpdate()
    {

    }
}
