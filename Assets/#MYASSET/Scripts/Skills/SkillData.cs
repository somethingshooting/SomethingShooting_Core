using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData : ScriptableObject
{
    public string SkillName;
    public string Type;
    public SkillType Skilltype;
    public string Json;

    public enum SkillType
    {
        passive,active,normal
    }
}
