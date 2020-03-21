using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour, ICharacterState
{
    public Parameter CurrentHP { get; } = new Parameter(10);

    public Parameter MaxHP { get; } = new Parameter(10);

    public Parameter Barrier { get; } = new Parameter(0);

    public Parameter ATK { get; } = new Parameter(1);

    public Parameter CoolTime { get; } = new Parameter(1);
}
