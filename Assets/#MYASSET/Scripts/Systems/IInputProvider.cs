using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IInputProvider
{
    IReadOnlyReactiveProperty<Vector3> PlayerMoveDirection { get; }

    IReadOnlyReactiveProperty<bool> NormalShotButtonPushed { get; }

    IReadOnlyReactiveProperty<bool> Skill1ButtonPushed { get; }
}