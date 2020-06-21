using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkillSelectButtonBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _SelectSkillButtonObj = null;
    [SerializeField] private GameObject _CruuentSkillButtonObj = null;

    public List<UI_SkillButtonController> SelectSkillButton = new List<UI_SkillButtonController>();
    public List<UI_SkillButtonController> CurrentSkillButton = new List<UI_SkillButtonController>();

    [SerializeField] private Transform _SelectTransfrom = null;
    private Transform _CurrentTransfrom = null;

    void Start()
    {
        if (_SelectTransfrom == null)
        {
            _SelectTransfrom = transform.root.Find("Select Skill Panel/Main/Select Scroll View/Viewport/Content");
            _CurrentTransfrom = transform.root.Find("Select Skill Panel/Main/Wearing Scroll View/Viewport/Content");
        }
    }

    public void InstanceNewButton(bool isSelect)
    {
        if (_SelectTransfrom == null)
        {
            _SelectTransfrom = transform.root.Find("Select Skill Panel/Main/Select Scroll View/Viewport/Content");
            _CurrentTransfrom = transform.root.Find("Select Skill Panel/Main/Wearing Scroll View/Viewport/Content");
        }

        GameObject button;
        UI_SkillButtonController buttonController;
        if (isSelect)
        {
            button = Instantiate(_SelectSkillButtonObj, _SelectTransfrom);
            buttonController = button.GetComponent<UI_SkillButtonController>();
            SelectSkillButton.Add(buttonController);
        }
        else
        {
            button = Instantiate(_CruuentSkillButtonObj, _CurrentTransfrom);
            buttonController = button.GetComponent<UI_SkillButtonController>();
            CurrentSkillButton.Add(buttonController);
        }

        // ボタンのテキストの書き換え
        Text text = button.transform.Find("Text").GetComponent<Text>();
        if (text != null)
        {
            text.text = buttonController.SkillData.SkillName;
        }
        else
        {
            Debug.Log("そのボタンの子にテキストは存在しません");
        }
    }
}
