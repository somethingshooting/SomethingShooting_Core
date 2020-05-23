using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "CreateJobData")]
public class JobData : ScriptableObject
{
    public string Name;
    public string Flaver;
    public List<JobData> PrerequisiteJob;
    public List<SkillData> GivenSkill;
    public StoryFlag Storyflag;

    [Serializable]
    public class StoryFlag
    {
        public int Ambition, Harmony, Intellect;
    }
}
