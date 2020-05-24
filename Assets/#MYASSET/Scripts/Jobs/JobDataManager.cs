using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobDataManager : MonoBehaviour
{
    [SerializeField]
    private List<JobData> _AllJobData;

    public List<JobData> AcquirableJobList(List<JobData> currentJobData)
    {
        List<JobData> datas = new List<JobData>();
        foreach (var job in _AllJobData)
        {
            if (!currentJobData.Contains(job))
            {
                bool acquirable = true;
                foreach (var pjob in job.PrerequisiteJob)
                {
                    acquirable = acquirable && currentJobData.Contains(pjob);
                }
                if (acquirable)
                {
                    datas.Add(job);
                }
            }
        }
        return datas;
    }
}
