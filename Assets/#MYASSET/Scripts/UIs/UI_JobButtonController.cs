using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_JobButtonController : MonoBehaviour
{
    private Button _Button = null;
    [SerializeField] private JobData _JobData = null;

    public UI_JobButtonController(JobData jobData)
    {
        _JobData = jobData;
    }

    void Start()
    {
        _Button = GetComponent<Button>();
        _Button.onClick.AddListener(OnButtonClick);
    }

    public void SetJobData(JobData jobData)
    {
        _JobData = jobData;
    }

    private void OnButtonClick()
    {
        var controller = transform.root.Find("SelectJobPanel").GetComponent<UI_JobPanelController>();
        if (controller == null)
        {
#if UNITY_EDITOR
            Debug.Log("取得できてねぇよ！ : " + transform.root.name);
#endif
            return;
        }
        controller.OnClockJobButton(_JobData);
    }
}
