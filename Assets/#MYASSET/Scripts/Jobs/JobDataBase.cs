using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CreateJobDataBase")]
public class JobDataBase : ScriptableObject
{
    public List<JobData> AllJobDatas = new List<JobData>();
}
