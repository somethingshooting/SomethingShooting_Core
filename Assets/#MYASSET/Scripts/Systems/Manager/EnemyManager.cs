using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : ManagerBase<EnemyManager>
{
    public List<EnemyBehaviour> EnemyList = new List<EnemyBehaviour>();

    private void Start()
    {
        foreach (var enm in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            EnemyList.Add(enm.GetComponent<EnemyBehaviour>());
        }
    }
}
