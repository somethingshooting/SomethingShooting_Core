﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFlagObject : MonoBehaviour
{
    public void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position+new Vector3(0,2,0),"QuestFlag");
    }
}
