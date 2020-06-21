using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkillSelectButtonBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _SelectSkillButtonObj = null;
    [SerializeField] private GameObject _CruuentSkillButtonObj = null;

    private List<UI_SkillButtonController> SelectSkillButton = new List<UI_SkillButtonController>();
    private List<UI_SkillButtonController> CurrentSkillButton = new List<UI_SkillButtonController>();

    private Transform _SelectTransfrom = null;
    private Transform _CurrentTransfrom = null;

    void Start()
    {
        if (_SelectTransfrom == null)
        {
            _SelectTransfrom = transform.root.Find("Select Skill Panel/Main/Select Scroll View/Viewport/Content");
            _CurrentTransfrom = transform.root.Find("Select Skill Panel/Main/Wearing Scroll View/Viewport/Content");
        }
    }

    /// <summary> ボタンのゲームオブジェクトを生成する </summary>
    /// <param name="isSelect">未装着スキルかどうか</param>
    /// <returns>生成したボタンにアタッチされている<see cref="UI_SkillButtonController"/></returns>
    private UI_SkillButtonController InstanceNewButton(bool isSelect)
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

        return buttonController;
    }

    private void SetButtonText(UI_SkillButtonController buttonController, SkillData skillData)
    {
        // ボタンのテキストの書き換え
        Text text = buttonController.transform.Find("Text").GetComponent<Text>();
        if (text != null)
        {
            text.text = buttonController.SkillData.SkillName;
        }
        else
        {
            Debug.Log("そのボタンの子にテキストは存在しません");
        }
    }

    public void ChangeActiveSkillPatternSelect(List<SkillData> datas)
    {
        var count = SelectSkillButton.Count;

        if (count >= datas.Count) // 余る or ピッタリ
        {
            for (int i = 0; i < count; i++)
            {
                if (i < datas.Count)
                {
                    SelectSkillButton[i].SetSkillData(datas[i]);
                    SetButtonText(SelectSkillButton[i], datas[i]);
                    if (SelectSkillButton[i].gameObject.activeSelf == false)
                    {
                        SelectSkillButton[i].gameObject.SetActive(true);
                    }
                }
                else if (SelectSkillButton[i].gameObject.activeSelf == true)
                {
                    SelectSkillButton[i].gameObject.SetActive(false);
                }
            }
        }
        else // 足りない
        {
            for (int i = 0; i < datas.Count; i++)
            {
                if (i < count) // 足りる
                {
                    SelectSkillButton[i].SetSkillData(datas[i]);
                    SetButtonText(SelectSkillButton[i], datas[i]);
                    if (SelectSkillButton[i].gameObject.activeSelf == false)
                    {
                        SelectSkillButton[i].gameObject.SetActive(true);
                    }
                }
                else // 足りない
                {
                    var button = InstanceNewButton(true);
                    button.SetSkillData(datas[i]);
                    SetButtonText(SelectSkillButton[i], datas[i]);
                }
            }
        }
    }

    public void ChangeActiveSkillPatternCurrent(List<SkillData> datas)
    {
        var count = CurrentSkillButton.Count;

        if (count >= datas.Count) // 余る or ピッタリ
        {
            for (int i = 0; i < count; i++)
            {
                if (i < datas.Count)
                {
                    CurrentSkillButton[i].SetSkillData(datas[i]);
                    SetButtonText(CurrentSkillButton[i], datas[i]);
                    if (CurrentSkillButton[i].gameObject.activeSelf == false)
                    {
                        CurrentSkillButton[i].gameObject.SetActive(true);
                    }
                }
                else if (CurrentSkillButton[i].gameObject.activeSelf == true)
                {
                    CurrentSkillButton[i].gameObject.SetActive(false);
                }
            }
        }
        else // 足りない
        {
            for (int i = 0; i < datas.Count; i++)
            {
                if (i < count) // 足りる
                {
                    CurrentSkillButton[i].SetSkillData(datas[i]);
                    SetButtonText(CurrentSkillButton[i], datas[i]);
                    if (CurrentSkillButton[i].gameObject.activeSelf == false)
                    {
                        CurrentSkillButton[i].gameObject.SetActive(true);
                    }
                }
                else // 足りない
                {
                    var button = InstanceNewButton(false);
                    button.SetSkillData(datas[i]);
                    SetButtonText(CurrentSkillButton[i], datas[i]);
                }
            }
        }
    }

    /// <summary> 装着中のNormalSkillを表示させる </summary>
    /// <param name="data"></param>
    public void ChangeActiveSkillPattern(SkillData data)
    {
        var count = CurrentSkillButton.Count;
        if (count < 1) // CurrentSkillButton.Count == 0なら
        {
            var button = InstanceNewButton(false);
            button.SetSkillData(data);
            SetButtonText(button, data);
            return;
        }


        if (count >= 1)
        {
            CurrentSkillButton[0].SetSkillData(data);
            SetButtonText(CurrentSkillButton[0], data);
            if (CurrentSkillButton[0].gameObject.activeSelf == false)
            {
                CurrentSkillButton[0].gameObject.SetActive(true);
            }

            for (int i = 1; i < count; i++)
            {
                if (CurrentSkillButton[i].gameObject.activeSelf == true)
                {
                    CurrentSkillButton[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
