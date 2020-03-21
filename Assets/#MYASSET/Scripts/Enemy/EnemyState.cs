using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour, ICharacterState
{
    public Parameter CurrentHP => _CurrentHP;
    [SerializeField] private Parameter _CurrentHP = new Parameter(10);

    public Parameter MaxHP => _MaxHP;
    [SerializeField] private Parameter _MaxHP = new Parameter(10);

    public Parameter Barrier => _Barrier;
    [SerializeField] private Parameter _Barrier = new Parameter(0);

    public Parameter ATK => _ATK;
    [SerializeField] private Parameter _ATK = new Parameter(1);

    public Parameter CoolTime => _CoolTime;
    [SerializeField] private Parameter _CoolTime = new Parameter(1);
}
