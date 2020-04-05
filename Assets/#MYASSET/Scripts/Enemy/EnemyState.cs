using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour, ICharacterState
{
    public ClampParameter HP => _HP;
    [SerializeField] private ClampParameter _HP = new ClampParameter(10,0,10);

    public Parameter<int> Barrier => _Barrier;
    [SerializeField] private Parameter<int> _Barrier = new Parameter<int>(0);

    public Parameter<int> ATK => _ATK;
    [SerializeField] private Parameter<int> _ATK = new Parameter<int>(1);
}
