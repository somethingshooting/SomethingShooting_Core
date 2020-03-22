using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StoryManager : MonoBehaviour
{
    [SerializeField]
    private float _ScrollSpeed=1;
    [SerializeField]
    private float _SpownZ;

    [SerializeField]
    private StageData[] _Stages;

    private QuestData[] _Quests;

    private int _CurrentQuest = 0;
    private int _CurrentEnemy = 0;
    private int _FlagLeft = 0;
    private float _CurrentDistance = 0;

    private bool _IsRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        var questlist = new List<QuestData>();
        for (int i = 0; i < _Stages.Length; i++)
        {
            questlist.AddRange(_Stages[i].Quests);
        }
        _Quests = questlist.ToArray();

        StartStory();
    }
    private void StartStory()
    {
        LoadQuest(0);
        _IsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_IsRunning)
        {
            _CurrentDistance += Time.deltaTime * _ScrollSpeed;
            SpownEnemy();
            if (_FlagLeft == 0)
            {
                _CurrentQuest++;
                if (_CurrentQuest < _Quests.Length)
                    LoadQuest(_CurrentQuest);
                else
                    _IsRunning = false;
            }
        }
        
    }

    private void SpownEnemy()
    {
        for (int i = _CurrentEnemy; i < _Quests[_CurrentQuest].Enemies.Length; i++)
        {
            if (_CurrentDistance >= _Quests[_CurrentQuest].Enemies[i].Position.z)
            {
                QuestData.EnemyData enemy = _Quests[_CurrentQuest].Enemies[i];
                var obj = Instantiate(enemy.Prefab);
                Vector3 pos = enemy.Position;
                pos.z = _SpownZ;
                obj.transform.position = pos;
                _CurrentEnemy++;
                if (enemy.Flag)
                    obj.GetComponent<IHitPointObject>().DeadSubject.Subscribe(_ => { _FlagLeft--; });
                    
            }
            else
            {
                return;
            }
        }
    }

    private void LoadQuest(int nom)
    {
        _CurrentQuest = nom;
        _CurrentEnemy = 0;
        _FlagLeft = _Quests[nom].FlagCount;
        _CurrentDistance = 0;
    }
}
