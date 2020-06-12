using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRestorater : MonoBehaviour
{
    public void SkillRestoration(GameObject obj,SkillData data)
    {
        Debug.Log(data.Type);
        Component skill = obj.AddComponent(System.Type.GetType(data.Type)) as Component;
        JsonUtility.FromJsonOverwrite(data.Json, skill);
    }
}
