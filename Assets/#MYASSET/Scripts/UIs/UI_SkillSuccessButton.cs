using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkillSuccessButton : MonoBehaviour
{
    private Button _Button = null;
    UI_SkillPanelController SkillPanelController = null;

    private void Start()
    {
        _Button = GetComponent<Button>();
        _Button.onClick.AddListener(OnButton);
        SkillPanelController = transform.root.Find("Select Skill Panel").GetComponent<UI_SkillPanelController>();
    }

    private void OnButton()
    {
        SkillPanelController.OnSuccess();
    }
}
