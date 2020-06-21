using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJobController : MonoBehaviour
{
    private JobDataManager _JobDataManager = null;

    [SerializeField] private List<JobData> _CurrentJobs = new List<JobData>();
    /// <summary> 現在取得しているJob </summary>
    public List<JobData> CurrentJobs => _CurrentJobs;

    public void AddJob(JobData data)
    {
        _CurrentJobs.Add(data);
    }

    /// <summary>
    /// 取得可能なJobのリストを返す
    /// </summary>
    /// <returns></returns>
    public List<JobData> AcquirableJobList()
    {
        if (_JobDataManager == null)
        {
            _JobDataManager = GameObject.FindWithTag("GameManager").GetComponent<JobDataManager>();
        }

        return _JobDataManager.AcquirableJobList(_CurrentJobs);
    }
}
