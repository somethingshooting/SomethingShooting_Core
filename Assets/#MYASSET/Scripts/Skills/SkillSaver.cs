using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SkillSaver : MonoBehaviour
{
    public Component Skillcomponent;

    [ContextMenu("SaveSkill")]
    public void SaveSkill()
    {
        ISkill skill = Skillcomponent as ISkill;

        var data = ScriptableObject.CreateInstance(typeof(SkillData)) as SkillData;
        AssetDatabase.CreateAsset(data, "Assets/#MYASSET/Scripts/Skills/SkillData/" + skill.SkillName + ".asset");
        data = new SkillData();
        data.SkillName = skill.SkillName;
        data.Json = JsonUtility.ToJson(Skillcomponent);
        data.Type = Skillcomponent.GetType();
    }
}
