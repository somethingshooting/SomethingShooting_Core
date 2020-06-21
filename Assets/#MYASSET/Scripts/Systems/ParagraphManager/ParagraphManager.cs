using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UniRx;
using UnityEngine.InputSystem;

[RequireComponent(typeof(TextEventUI))]
public class ParagraphManager : MonoBehaviour
{

    [SerializeField] private ParagraphData[] MainStory;
    [SerializeField] private ParagraphData[] BranchStory;
    [SerializeField] private ParagraphData ComplexStory;
    public int[] StoryParamater;

    [SerializeField] private bool _isMoving = true;
    [SerializeField] private float _CurrentDistance;
    [SerializeField] private float _ScrollSpeed = 0.5f;
    [SerializeField] private float _SpownZ = 5;

    private PlayerInput input;
    private void Awake()
    {
        CurrentParagraph = MainStory[0];
        textUI = GetComponent<TextEventUI>();
        input = GetComponent<PlayerInput>();
    }

    private ParagraphData CurrentParagraph;
    private int _EnemyCount = 0,_BossCount = 0, _TextCount = 0, _JobSelectCout = 0;
    private bool _EnemyEnd = false,_BossEnd = false, _TextEnd = false, _JobSelectEnd = false;
    private void Update()
    {
        if (CurrentParagraph == null)
            return;

        if (_isMoving)
        {
            _CurrentDistance += _ScrollSpeed * Time.deltaTime;
        }
        if (!_EnemyEnd)
        {
            if (CurrentParagraph.EnemyBlocks.Length > _EnemyCount)
            {
                for (int i = _EnemyCount; i < CurrentParagraph.EnemyBlocks.Length; i++)
                {
                    if (_CurrentDistance >= CurrentParagraph.EnemyBlocks[i].Position.z)
                    {
                        EnemyBlockFunction(CurrentParagraph.EnemyBlocks[i]);
                        _EnemyCount++;
                    }
                    else
                    {
                        i += CurrentParagraph.EnemyBlocks.Length;
                    }
                }
            }
            else
                _EnemyEnd = true;
        }
        if (!_BossEnd && _isMoving)
        {
            if (CurrentParagraph.BossBlocks.Length > _BossCount)
            {
                for (int i = _BossCount; i < CurrentParagraph.BossBlocks.Length; i++)
                {
                    if (_CurrentDistance >= CurrentParagraph.BossBlocks[i].Position.z)
                    {
                        BossBlockFunction(CurrentParagraph.BossBlocks[i]);
                        _BossCount++;
                    }
                    else
                    {
                        i += CurrentParagraph.BossBlocks.Length;
                    }
                }
            }
            else
                _BossEnd = true;
        }
        if (!_TextEnd && _isMoving)
        {
            if (CurrentParagraph.TextBlocks.Length > _TextCount)
            {
                if (_CurrentDistance >= CurrentParagraph.TextBlocks[_TextCount].Position.z)
                {
                    TextBlockFunction(CurrentParagraph.TextBlocks[_TextCount]);
                    _TextCount++;
                }
            }
            else
                _TextEnd = true;
        }
        if (!_JobSelectEnd && _isMoving)
        {
            if (CurrentParagraph.JobSelectBlocks.Length > _JobSelectCout)
            {
                if (_CurrentDistance >= CurrentParagraph.JobSelectBlocks[_JobSelectCout].Position.z)
                {
                    JobSelectBlockFunction(CurrentParagraph.JobSelectBlocks[_JobSelectCout]);
                    _JobSelectCout++;
                }
            }
            else
                _JobSelectEnd = true;
        }
        if (_EnemyEnd &&_BossEnd&& _TextEnd && _JobSelectEnd)
            NextParagraph();
    }
    private int _ParagraphProgress = 0;
    private void NextParagraph()
    {
        _CurrentDistance = 0;
        _ParagraphProgress++;
        _EnemyCount = 0; _BossCount = 0; _TextCount = 0; _JobSelectCout = 0;
        _EnemyEnd = false; _BossEnd = false; _TextEnd = false; _JobSelectEnd = false;
        if (_ParagraphProgress<MainStory.Length)
        {
            CurrentParagraph = MainStory[_ParagraphProgress];
        }else if(_ParagraphProgress == MainStory.Length)
        {
            bool isEqual = false;
            int maxnum = 0;
            for (int i = 1; i < BranchStory.Length; i++)
            {
                if (StoryParamater[i] > StoryParamater[maxnum])
                    maxnum = i;
                else if (StoryParamater[i] == StoryParamater[maxnum])
                    isEqual = true;return;
            }
            if (isEqual)
                CurrentParagraph = ComplexStory;
            else
                CurrentParagraph = BranchStory[maxnum];
        }
        else
        {
            CurrentParagraph = null;
            //クリア処理
            SceneManager.Instance.ChangeScene("_Clear");
        }
    }
    //-----------------------------------------------------------------------------------------------------------------------
    private void EnemyBlockFunction(ParagraphData.EnemyBlock block)
    {
        var obj = Instantiate(block.Prefab);
        Vector3 pos = block.Position;
        pos.z = _SpownZ;
        obj.transform.position = pos;
    }
    private int _BossLeft = 0;
    private void BossBlockFunction(ParagraphData.BossBlock block)
    {
        _isMoving = false;
        var obj = Instantiate(block.Prefab);
        Vector3 pos = block.Position;
        pos.z = _SpownZ;
        obj.transform.position = pos;
        obj.GetComponent<EnemyBehaviour>().DeadSubject.Subscribe(_ => { Debug.Log("boss"); _BossLeft--; if (_BossLeft <= 0) { _isMoving = true; } });
    }
    private TextEventUI textUI;
    private void TextBlockFunction(ParagraphData.TextBlock block)
    {
        _isMoving = false;
        input.SwitchCurrentActionMap("Story");

        textUI.StartTextEvent(block);
    }
    public void TextEventEnd()
    {
        _isMoving = true;
        input.SwitchCurrentActionMap("Battle");
    }
    [SerializeField] private GameObject JobPanel;
    [SerializeField] private GameObject SkillPanel;
    private void JobSelectBlockFunction(ParagraphData.JobSelectBlock block)
    {
        _isMoving = false;
        JobPanel.SetActive(true);
    }
    public void JobSelectEnd()
    {
        JobPanel.SetActive(false);
        SkillPanel.SetActive(true);
    }
    public void SkillSelectEnd()
    {
        SkillPanel.SetActive(false);
        _isMoving = true;
    }
  /*  //------------------------------------------------------------------------------------------------------------------------
    [SerializeField] private string name;
    [ContextMenu("CreateParagraph")]
    private void CreateParagraphData()
    {
        var data = ScriptableObject.CreateInstance(typeof(ParagraphData)) as ParagraphData;
        AssetDatabase.CreateAsset(data, "Assets/#MYASSET/Scripts/Systems/ParagraphManager/" + name + ".asset");
    }*/
}
