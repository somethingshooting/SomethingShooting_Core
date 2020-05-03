using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class En_Boss_First : EnemyBehaviour
{
    [SerializeField] private List<Vector3> _CheckPoint = new List<Vector3>();

    [SerializeField] private float _MoveSpeed = 1.0f;

    [SerializeField] private int _Phase = -2;

    private SkillController _Controller = null;

    private bool A1 = false, A2 = false, A3 = false;

    protected override void Init()
    {
        _Controller = GetComponent<SkillController>();
        _Phase = -2;

        GameObject.FindWithTag("GameManager").GetComponent<UIController>().BossSet(_State, name);

        DeadSubject
            .Subscribe(_ => SceneManager.Instance.ChangeScene("_Clear"));
    }

    protected void Update()
    {
        switch (_Phase)
        {
            case -2: // Init
                PhaseMTwo();
                break;
            case -1: // End

                break;
            case 0: // a-b
                PhaseZer();
                break;
            case 1: // b-c
                PhaseOne();
                break;
            case 2: // c-d
                PhaseTwo();
                break;
            case 3: // S2-1
                PhaseThr();
                break;
            case 4: // S2-2
                PhaseFou();
                break;
            case 5: // S0
                PhaseFiv();
                break;
            case 6: // d-e
                PhaseSix();
                break;
            case 7: // e-a
                PhaseSev();
                break;
            case 8: // d-a
                PhaseEig();
                break;
            default:
                break;
        }
    }

    private void PhaseMTwo()
    {
        transform.Translate((_CheckPoint[3]-transform.position).normalized * Time.deltaTime * _MoveSpeed);
        if (Vector3.Distance(transform.position, _CheckPoint[3]) < 0.2f)
        {
            _Phase = 8;
        }
    }

    private void PhaseZer()
    {
        transform.Translate((_CheckPoint[1] - _CheckPoint[0]).normalized * Time.deltaTime * _MoveSpeed);
        if (Vector3.Distance(transform.position,_CheckPoint[1]) < 0.2f)
        {
            _Phase++;
        }
        PlaySkillTargetPlayer();
    }

    private void PhaseOne()
    {
        transform.Translate((_CheckPoint[2] - _CheckPoint[1]).normalized * Time.deltaTime * _MoveSpeed);
        if (Vector3.Distance(transform.position, _CheckPoint[2]) < 0.2f)
        {
            _Phase++;
        }
        PlaySkillWidthShot();
    }
    private void PhaseTwo()
    {
        transform.Translate((_CheckPoint[3] - _CheckPoint[2]).normalized * Time.deltaTime * _MoveSpeed);
        if (Vector3.Distance(transform.position, _CheckPoint[3]) < 0.2f)
        {
            _Phase++;
        }
        PlaySkillWidthShot();
    }
    private void PhaseThr()
    {
        if (!A1)
        {
            A1 = true;
            PlayThr();
        }
        if (_Controller.ActiveSkills[3].IsRunning.Value == false)
        {
            _Phase++;
            A1 = false;
        }
    }
    private void PhaseFou()
    {
        if (!A2)
        {
            A2 = true;
            PlayFor();
        }
        if (_Controller.ActiveSkills[4].IsRunning.Value == false)
        {
            _Phase++;
            A2 = false;
        }
    }
    private void PhaseFiv()
    {
        if (!A3)
        {
            A3 = true;
            PlaySkillAroundBurst();
        }
        if (_Controller.ActiveSkills[0].IsRunning.Value == false)
        {
            _Phase++;
            A3 = false;
        }
    }
    private void PhaseSix()
    {
        transform.Translate((_CheckPoint[4] - _CheckPoint[3]).normalized * Time.deltaTime * _MoveSpeed);
        if (Vector3.Distance(transform.position, _CheckPoint[4]) < 0.2f)
        {
            _Phase++;
        }
        PlaySkillWidthShot();
    }
    private void PhaseSev()
    {
        transform.Translate((_CheckPoint[0] - _CheckPoint[4]).normalized * Time.deltaTime * _MoveSpeed);
        if (Vector3.Distance(transform.position, _CheckPoint[0]) < 0.2f)
        {
            _Phase = 0;
        }
        PlaySkillWidthShot();
    }
    private void PhaseEig()
    {
        transform.Translate((_CheckPoint[0] - _CheckPoint[3]).normalized * Time.deltaTime * _MoveSpeed);
        if (Vector3.Distance(transform.position, _CheckPoint[0]) < 0.2f)
        {
            _Phase = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        foreach (var pos in _CheckPoint)
        {
            Gizmos.DrawSphere(pos, 0.1f);
        }
    }

    private void PlaySkillAroundBurst()
    {
        _Controller.PlayAstiveSkill(0);
    }

    private void PlaySkillTargetPlayer()
    {
        _Controller.PlayAstiveSkill(1);
    }

    private void PlaySkillWidthShot()
    {
        _Controller.PlayAstiveSkill(2);
    }

    private void PlayThr()
    {
        _Controller.PlayAstiveSkill(3);
    }

    private void PlayFor()
    {
        _Controller.PlayAstiveSkill(4);
    }
}
