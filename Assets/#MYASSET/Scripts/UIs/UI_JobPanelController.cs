using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_JobPanelController : MonoBehaviour
{
    private PlayerJobController _PlayerJobController = null;
    [SerializeField] private GameObject _JobButtonObj = null;
    [SerializeField] private GameObject _SkillPanelObj = null;
    private Transform _JobPanelContentTransform = null;
    private Transform _SkillNameTextContentTransfrom = null;
    private GameObject _DetailPanel = null;

    private List<UI_JobButtonController> _UI_Jobs = new List<UI_JobButtonController>();

    [SerializeField] private Text _JobName_Text = null;
    [SerializeField] private Text _JobFlever_Text = null;
    public JobData SelectJob { get; private set; } = null;
    private List<Text> _SkillName_Text = new List<Text>();

    void Start()
    {
        _PlayerJobController = GameObject.FindWithTag("Player").GetComponent<PlayerJobController>();
        _DetailPanel = transform.Find("DetailPanel").gameObject;
        if (_DetailPanel.activeSelf)
        {
            _DetailPanel.SetActive(false);
        }
        _JobPanelContentTransform = transform.Find("Scroll View/Viewport/Content");
        _SkillNameTextContentTransfrom = transform.Find("DetailPanel/Scroll View/Viewport/Content");
;    }

    private void OnEnable()
    {
        if (_PlayerJobController == null)
        {
            _PlayerJobController = GameObject.FindWithTag("Player").GetComponent<PlayerJobController>();
        }

        var acquirableJobList = _PlayerJobController.AcquirableJobList();
        var jobCount = acquirableJobList.Count;

        for (int i = 0; i < jobCount; i++)
        {
            if (_UI_Jobs.Count >= i + 1)
            {
                if (!_UI_Jobs[i].gameObject.activeSelf)
                {
                    _UI_Jobs[i].gameObject.SetActive(true);
                }
                _UI_Jobs[i].SetJobData(acquirableJobList[i]);
            }
            else
            {
                InstantiateJobButton(acquirableJobList[i]);
            }
        }

        if (_UI_Jobs.Count > jobCount)
        {
            for (int i = _UI_Jobs.Count - 1; i >= jobCount; i--)
            {
                _UI_Jobs[i].gameObject.SetActive(false);
            }
        }
    }

    public void CloseJobSelectPanel()
    {
        if (_DetailPanel.activeSelf)
        {
            _DetailPanel.SetActive(false);
        }

        gameObject.SetActive(false);
    }

    private void InstantiateJobButton(JobData dataBase)
    {
        if (_JobPanelContentTransform == null)
        {
            _JobPanelContentTransform = transform.Find("Scroll View/Viewport/Content");
        }
        var obj = Instantiate(_JobButtonObj, _JobPanelContentTransform);
        _UI_Jobs.Add(obj.GetComponent<UI_JobButtonController>());
    }

    public void OnClockJobButton(JobData jobData)
    {
        if (_DetailPanel != null && !_DetailPanel.activeSelf)
        {
            _DetailPanel.SetActive(true);
        }

        _JobName_Text.text = jobData.Name;
        _JobFlever_Text.text = jobData.Name;
        SelectJob = jobData;

        var givenSkills = jobData.GivenSkill;
        var skillCount = givenSkills.Count;
        for (int i = 0; i < skillCount; i++)
        {
            if (_SkillName_Text.Count >= i+1)
            {
                if (!_SkillName_Text[i].transform.parent.gameObject.activeSelf)
                {
                    _SkillName_Text[i].transform.parent.gameObject.SetActive(true);
                }
                _SkillName_Text[i].text = givenSkills[i].SkillName;
            }
            else
            {
                InstiantiateSkillPanel(givenSkills[i].SkillName);
            }
        }

        if (_SkillName_Text.Count > skillCount)
        {
            for (int i = _SkillName_Text.Count - 1; i >= skillCount; i--)
            {
                _SkillName_Text[i].transform.parent.gameObject.SetActive(false);
            }
        }
    }

    private void InstiantiateSkillPanel(string text)
    {
        var obj = Instantiate(_SkillPanelObj, _SkillNameTextContentTransfrom);
        var textComponent = obj.transform.Find("Text").GetComponent<Text>();
        textComponent.text = text;
        _SkillName_Text.Add(textComponent);
    }
}
