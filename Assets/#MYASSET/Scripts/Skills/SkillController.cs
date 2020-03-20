using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    private IInputProvider InputProvider;

    public ActiveSkill NormalShotSkill { get; private set; }

    public List<ActiveSkill> ActiveSkills { get; private set; }

    public List<PassiveSkill> PassiveSkills { get; private set; }

    void Start()
    {
        
    }

    public void ChangeSkill()
    {

    }

    public void RemoveSkill()
    {

    }

    public void AddSkill()
    {

    }
}
