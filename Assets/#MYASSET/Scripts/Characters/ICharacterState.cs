using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterState
{
  /*  Parameter CurrentHP { get; }

    Parameter MaxHP { get; }*/

    ClampParameter HP { get; }

    Parameter Barrier { get; }

    Parameter ATK { get; }
}
