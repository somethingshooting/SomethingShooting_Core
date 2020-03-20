using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : ScriptableObject
{
    public EnemyData[] Enemies;
    public class EnemyData
    {
        public Vector3 Position;
        public GameObject Prefab;
        public bool Frag;
    }
}
