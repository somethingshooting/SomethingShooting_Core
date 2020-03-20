using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFlagObject : MonoBehaviour
{
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawIcon(transform.position,"QuestFlag");
    }
}
