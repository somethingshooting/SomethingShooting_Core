using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class En_Boss_First : EnemyBehaviour
{
    [SerializeField] private List<Vector3> _CheckPoint = new List<Vector3>();

    [SerializeField] private float _MoveSpeed = 1.0f;

    [SerializeField] private int _Phase = -2;

    private SkillController _Controller = null;

    protected override void Init()
    {
        _Controller = GetComponent<SkillController>();
    }

    protected void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        foreach (var pos in _CheckPoint)
        {
            Gizmos.DrawSphere(pos, 0.1f);
        }
    }

    private void PlaySkillBurst()
    {
     
    }
}
