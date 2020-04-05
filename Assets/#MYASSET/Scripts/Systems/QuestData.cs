using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : ScriptableObject
{
    public int FlagCount;
    public EnemyData[] Enemies;
    [Serializable]
    public class EnemyData
    {
        public Vector3 Position;
        public GameObject Prefab;
        public bool Flag;
    }
}
