using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SkillButtonController : MonoBehaviour
{
    [SerializeField] private bool _IsSelect = false;

    public SkillData SkillData { get; private set; } = null;
    private Button _Button = null;

    private void Start()
    {
        _Button = GetComponent<Button>();
        _Button.onClick.AddListener(OnButton);
    }

    public void SetSkillData(SkillData data)
    {
        SkillData = data;
    }

    public void OnButton()
    {
        Debug.Log(SkillData.SkillName + "のボタンが押されました");
    }
}
