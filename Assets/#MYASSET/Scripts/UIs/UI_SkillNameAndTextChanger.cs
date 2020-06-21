using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class UI_SkillNameAndTextChanger : MonoBehaviour
{
    private Text _SelectSkillName = null;
    private Text _SelectSkillFlever = null;
    private Text _CurrentSkillName = null;
    private Text _CurrentSkillFlever = null;

    private UI_SkillPanelController SkillPanelController = null;

    void Start()
    {
        _SelectSkillName    = transform.Find("Main/Detail Panel/Select Skill Panel/SkillName_Text").GetComponent<Text>();
        _SelectSkillFlever  = transform.Find("Main/Detail Panel/Select Skill Panel/Flever_Text").GetComponent<Text>();
        _CurrentSkillName   = transform.Find("Main/Detail Panel/Current Skill Panel/SkillName_Text").GetComponent<Text>();
        _CurrentSkillFlever = transform.Find("Main/Detail Panel/Current Skill Panel/Flever_Text").GetComponent<Text>();

        SkillPanelController = GetComponent<UI_SkillPanelController>();

        SkillPanelController.SelectSkillData
            .Subscribe(data => SetSelectTexts(data));

        SkillPanelController.CurrentSkillData
            .Subscribe(data => SetCurrentTexts(data));
    }

    private void SetSelectTexts(SkillData data)
    {
        if (data != null)
        {
            _SelectSkillName.text = data.SkillName;
            _SelectSkillFlever.text = "This skill type is " + data.Skilltype + ".\n" + data.Flever;
        }
        else
        {
            _SelectSkillName.text = "Skill name here.";
            _SelectSkillFlever.text = "This Skill is None Type.\n" + "Skill Flever here.";
        }
    }

    private void SetCurrentTexts(SkillData data)
    {
        if (data != null)
        {
            _CurrentSkillName.text = data.SkillName;
            _CurrentSkillFlever.text = "This skill type is " + data.Skilltype + ".\n" + data.Flever;
        }
        else
        {
            _CurrentSkillName.text = "Skill name here.";
            _CurrentSkillFlever.text = "This Skill is None Type.\n" + "Skill Flever here.";
        }

    }
}
