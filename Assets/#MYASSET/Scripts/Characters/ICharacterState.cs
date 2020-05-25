using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterState
{
  /*  Parameter CurrentHP { get; }

    Parameter MaxHP { get; }*/

    ClampParameter<int> HP { get; }

    Parameter<int> Barrier { get; }

    Parameter<int> ATK { get; }
}
