using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour, ICharacterState
{
    public ClampParameter HP => _HP;
    [SerializeField] private ClampParameter _HP = new ClampParameter(10,0,10);

    public Parameter Barrier => _Barrier;
    [SerializeField] private Parameter _Barrier = new Parameter(0);

    public Parameter ATK => _ATK;
    [SerializeField] private Parameter _ATK = new Parameter(1);
}
