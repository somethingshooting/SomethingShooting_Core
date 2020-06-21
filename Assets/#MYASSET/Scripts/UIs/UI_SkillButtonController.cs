using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UI_SkillButtonController : MonoBehaviour
{
    [SerializeField] private bool _IsSelect = false;

    public SkillData SkillData { get; private set; } = null;
    private Button _Button = null;
    UI_SkillPanelController SkillPanelController = null;

    private void Start()
    {
        _Button = GetComponent<Button>();
        _Button.onClick.AddListener(OnButton);
        SkillPanelController = transform.root.Find("Select Skill Panel").GetComponent<UI_SkillPanelController>();
    }

    public void SetSkillData(SkillData data)
    {
        SkillData = data;
    }

    private void OnButton()
    {
        SkillPanelController.OnSelectOrCurrentButtonDown(_IsSelect, SkillData);
    }
}
