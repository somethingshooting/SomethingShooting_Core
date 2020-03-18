using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class InputController : MonoBehaviour, IInputProvider
{
    public IReadOnlyReactiveProperty<Vector3> PlayerMoveDirection => _PlayerMoveDirection;
    private ReactiveProperty<Vector3> _PlayerMoveDirection = new ReactiveProperty<Vector3>();

    public IReadOnlyReactiveProperty<bool> NormalShotButtonPushed => _NormalShotButtonPushed;
    private BoolReactiveProperty _NormalShotButtonPushed = new BoolReactiveProperty();

    public IReadOnlyReactiveProperty<bool> Skill1ButtonPushed => _Skill1ButtonPushed;
    private BoolReactiveProperty _Skill1ButtonPushed = new BoolReactiveProperty();

    void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            .Subscribe(_ => SetPlayerMoveDirection());

        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                SetSkill1Button();
                SetNormalShotButton();
            });
    }

    private void SetPlayerMoveDirection()
    {
        _PlayerMoveDirection.Value = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    private void SetNormalShotButton()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _NormalShotButtonPushed.Value = true;
        }
        else
        {
            _NormalShotButtonPushed.Value = false;
        }
    }

    private void SetSkill1Button()
    {

        if (Input.GetMouseButtonDown(1))
        {
            _Skill1ButtonPushed.Value = true;
        }
        else
        {
            _Skill1ButtonPushed.Value = false;
        }
    }
}