using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRestorater : MonoBehaviour
{
    public Component SkillRestoration(GameObject obj,SkillData data)
    {
        Debug.Log(data.Type);
        Component skill = obj.AddComponent(System.Type.GetType(data.Type)) as Component;
        JsonUtility.FromJsonOverwrite(data.Json, skill);
        return skill;
    }
    public Component SkillReplace(Component skill,SkillData data)
    {
        if (skill.GetType().ToString() != data.Type)
        {
            var obj = skill.gameObject;
            Destroy(skill);
            skill = obj.AddComponent(System.Type.GetType(data.Type)) as Component;
        }
        JsonUtility.FromJsonOverwrite(data.Json, skill);
        return skill;
    }
}
