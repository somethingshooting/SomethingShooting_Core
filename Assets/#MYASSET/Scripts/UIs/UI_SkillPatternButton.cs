using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UI_SkillPatternButton : MonoBehaviour
{
    [SerializeField] private UI_SkillPanelController.SelectSkillPattern _SkillPattern = UI_SkillPanelController.SelectSkillPattern.None;

    private Button _Button = null;
    private UI_SkillPanelController _PanelController = null;

    private void Start()
    {
        if (_PanelController == null)
        {
            _PanelController = transform.root.Find("Select Skill Panel").GetComponent<UI_SkillPanelController>();
        }

        _PanelController.SelectPattern
            .Subscribe(_=>UpdateButtonInteractable());

        if (_Button == null)
        {
            _Button = GetComponent<Button>();
        }

        _Button.onClick.AddListener(OnButtonClick);
    }

    private void OnEnable()
    {
        if (_Button == null)
        {
            _Button = GetComponent<Button>();
        }

        if (_PanelController == null)
        {
            _PanelController = transform.root.Find("Select Skill Panel").GetComponent<UI_SkillPanelController>();
        }

        UpdateButtonInteractable();
    }

    private void UpdateButtonInteractable()
    {
        if (_SkillPattern == _PanelController.SelectPattern.Value)
        {
            _Button.interactable = false;
        }
        else
        {
            if (!_Button.interactable) { _Button.interactable = true; }
        }
    }

    private void OnButtonClick()
    {
        _PanelController.ChangePattern(_SkillPattern);
    }
}
