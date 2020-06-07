using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UniRx;

[RequireComponent(typeof(TextEventUI))]
public class ParagraphManager : MonoBehaviour
{

    [SerializeField] private ParagraphData[] MainStory;
    [SerializeField] private ParagraphData[] BranchStory;
    [SerializeField] private ParagraphData ComplexStory;
    public int[] StoryParamater;
    public class ParagraphData:ScriptableObject
    {
        public int FlagCount;
      //  public CharacterData[] Characters;
        public EnemyBlock[] EnemieBlocks;
        public BossBlock[] BossBlocks;
        public TextBlock[] TextBlocks;
        public JobSelectBlock[] JobSelectBlocks;
        public abstract class EventBlock
        {
            public Vector3 Position;
        }
        [Serializable]
        public class EnemyBlock:EventBlock
        {
            public GameObject Prefab;
        }
        [Serializable]
        public class BossBlock : EventBlock
        {
            public GameObject Prefab;
        }
        [Serializable]
        public class TextBlock:EventBlock
        {
            public CharacterData[] Characters;
            public TextData[] Texts;
            [Serializable]
            public class TextData
            {
                public int Character;
                public string Message;
            }
        }
        [Serializable]
        public class CharacterData
        {
            public string Name;
            public Sprite Image;
        }
        [Serializable]
        public class JobSelectBlock:EventBlock
        {
        }
    }
      private bool _isMoving = true;
     private float _CurrentDistance;
    [SerializeField] private float _ScrollSpeed = 0.5f;
    [SerializeField] private float _SpownZ = 5;

    private void Awake()
    {
        CurrentParagraph = MainStory[0];
        textUI = GetComponent<TextEventUI>();
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
            if (CurrentParagraph.EnemieBlocks.Length > _EnemyCount)
            {
                for (int i = _EnemyCount; i < CurrentParagraph.EnemieBlocks.Length; i++)
                {
                    if (_CurrentDistance >= CurrentParagraph.EnemieBlocks[i].Position.z)
                    {
                        EnemyBlockFunction(CurrentParagraph.EnemieBlocks[i]);
                        _EnemyCount++;
                    }
                    else
                        return;
                }
            }
            else
                _EnemyEnd = true;
        }
        if (!_BossEnd&& _isMoving)
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
                        return;
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
        obj.GetComponent<EnemyBehaviour>().DeadSubject.Subscribe(_ => { _BossLeft--; if (_BossLeft <= 0) { _isMoving = true; } });
    }
    private TextEventUI textUI;
    private void TextBlockFunction(ParagraphData.TextBlock block)
    {
        _isMoving = false;
        textUI.StartTextEvent(block);
    }
    public void TextEventEnd()
    {
        _isMoving = true;
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
    //------------------------------------------------------------------------------------------------------------------------
    [SerializeField] private string name;
    [ContextMenu("CreateParagraph")]
    private void CreateParagraphData()
    {
        var data = ScriptableObject.CreateInstance(typeof(ParagraphData)) as ParagraphData;
        AssetDatabase.CreateAsset(data, "Assets/#MYASSET/Scripts/Systems/ParagraphManager/" + name + ".asset");
    }
}
