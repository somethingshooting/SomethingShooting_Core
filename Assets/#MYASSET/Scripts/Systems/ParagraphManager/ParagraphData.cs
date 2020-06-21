using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParagraphData : ScriptableObject
{
    public int FlagCount;
    //  public CharacterData[] Characters;
    public EnemyBlock[] EnemyBlocks;
    public BossBlock[] BossBlocks;
    public TextBlock[] TextBlocks;
    public JobSelectBlock[] JobSelectBlocks;
    public abstract class EventBlock
    {
        public Vector3 Position;
    }
    [Serializable]
    public class EnemyBlock : EventBlock
    {
        public GameObject Prefab;
    }
    [Serializable]
    public class BossBlock : EventBlock
    {
        public GameObject Prefab;
    }
    [Serializable]
    public class TextBlock : EventBlock
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
    public class JobSelectBlock : EventBlock
    {
    }
}
