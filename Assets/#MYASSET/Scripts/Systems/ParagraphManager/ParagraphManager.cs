using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParagraphManager : MonoBehaviour
{
    public ParagraphData[] Story;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (var paradata in Story)
        {
            for (int i = 0; i < paradata.Events.Length; i++)
            {
               
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public BattleEvent obj;
    public string json;
    [ContextMenu("jsontest")]
    public void jsontest()
    {
        json = JsonUtility.ToJson(obj);
    }

    //データクラスの定義
    public class ParagraphData
    {
      public  ParagraphEvent[] Events;
    }
    public abstract class ParagraphEvent
    {
        public Type Type;
    }
    [Serializable]
    public class BattleEvent : ParagraphEvent
    {
        public int FlagCount;
        public EnemyData[] Enemies;
        [Serializable]
        public class EnemyData
        {
            public Vector3 Position;
            public GameObject Prefab;
            public bool Flag;
        }
        //
        public TextAsset Text;
    }
    [Serializable]
    public class TextEvent : ParagraphEvent
    {
        public CharacterData[] Characters;
        public TextData[] Texts;
        [Serializable]
        public class CharacterData
        {
            public string Name;
            public Image Image;
        }
        [Serializable]
        public class TextData
        {
            public int Character;
            public string Message;
        }
        //
        public TextAsset Text;
    }
    [Serializable]
    public class JobSelectEvent : ParagraphEvent
    {
    }
}
