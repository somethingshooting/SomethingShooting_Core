using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UI_JobSuccessButton : MonoBehaviour
{
    private Button _Button = null;
    private PlayerJobController _PlayerJobController = null;

    void Start()
    {
        _Button = GetComponent<Button>();
        _PlayerJobController = GameObject.FindWithTag("Player").GetComponent<PlayerJobController>();
        _Button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        var jobPanelController = transform.root.Find("SelectJobPanel").GetComponent<UI_JobPanelController>();
        var jobData =jobPanelController.SelectJob;
        if (jobData == null)
        {
            return;
        }
        _PlayerJobController.AddJob(jobData);
        jobPanelController.CloseJobSelectPanel();
    }
}
