using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJobController : MonoBehaviour
{
    private JobDataManager _JobDataManager = null;
    private SkillController _SkillController = null;

    [SerializeField]
    private List<JobData> Jobs = new List<JobData>();

    private void Start()
    {
        _SkillController = GetComponent<SkillController>();
        _JobDataManager = GameObject.FindWithTag("GameManager").GetComponent<JobDataManager>();
    }

    public void AddJob(JobData data)
    {
        Jobs.Add(data);
    }

    /// <summary>
    /// 取得可能なJobのリストを返す
    /// </summary>
    /// <returns></returns>
    public List<JobData> AcquirableJobList() => _JobDataManager.AcquirableJobList(Jobs);
}
