using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterState
{
    Parameter CurrentHP { get; }

    Parameter MaxHP { get; }

    Parameter Barrier { get; }

    Parameter ATK { get; }

    Parameter CoolTime { get; }
}
