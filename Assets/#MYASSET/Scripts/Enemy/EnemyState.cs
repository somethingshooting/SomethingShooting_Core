using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour, ICharacterState
{
    public ClampParameter<int> HP => _HP;
    [SerializeField] private ClampParameter<int> _HP = new ClampParameter<int>(10,0,10);

    public Parameter<int> Barrier => _Barrier;
    [SerializeField] private Parameter<int> _Barrier = new Parameter<int>(0);

    public Parameter<int> ATK => _ATK;
    [SerializeField] private Parameter<int> _ATK = new Parameter<int>(1);
}
