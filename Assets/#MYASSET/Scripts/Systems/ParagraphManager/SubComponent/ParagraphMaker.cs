using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

public class ParagraphMaker : MonoBehaviour
{
    [SerializeField]
    private string _Name;
    private ParagraphData data;
    [ContextMenu("ScanParagraph")]
    private void StartScan()
    {
        data = ScriptableObject.CreateInstance(typeof(ParagraphData)) as ParagraphData;
        
        ScanEnemy();
        ScanBoss();
        ScanText();
        ScanJobSelect();
        AssetDatabase.CreateAsset(data, "Assets/#MYASSET/Scripts/Systems/ParagraphManager/" + _Name + ".asset");
    }
    private void ScanEnemy()
    {
        var enemylist = new List<GameObject>();
        enemylist.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        for (int i = 0; i < enemylist.Count; i++)
        {
            if(enemylist[i].GetComponent<BossFlag>() != null)
            {
                enemylist.RemoveAt(i);
                i--;
            }
        }
        enemylist = _SortWithZ(enemylist);
        data.EnemyBlocks = new ParagraphData.EnemyBlock[enemylist.Count];
        for (int i = 0; i < enemylist.Count; i++)
        {
            data.EnemyBlocks[i] = new ParagraphData.EnemyBlock();
            data.EnemyBlocks[i].Position = enemylist[i].transform.position;
            data.EnemyBlocks[i].Prefab = PrefabUtility.GetCorrespondingObjectFromSource(enemylist[i]);
        }
    }
    private List<GameObject> _SortWithZ(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count-1; i++)
        {
            int min = i;
            for (int g = i+1; g < objects.Count; g++)
            {
                if (objects[g].transform.position.z<objects[min].transform.position.z)
                {
                    min = g;
                }
            }
            GameObject ins = objects[i];
            objects[i] = objects[min];
            objects[min] = ins;
        }
        return objects;
    }
    private void ScanBoss()
    {
        var enemylist = new List<GameObject>();
        enemylist.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        for (int i = 0; i < enemylist.Count; i++)
        {
            if (enemylist[i].GetComponent<BossFlag>() == null)
            {
                enemylist.RemoveAt(i);
                i--;
            }
        }
        enemylist = _SortWithZ(enemylist);
        data.BossBlocks = new ParagraphData.BossBlock[enemylist.Count];
        for (int i = 0; i < enemylist.Count; i++)
        {
            data.BossBlocks[i] = new ParagraphData.BossBlock();
            data.BossBlocks[i].Position = enemylist[i].transform.position;
            data.BossBlocks[i].Prefab = PrefabUtility.GetCorrespondingObjectFromSource(enemylist[i]);
        }
    }
    private void ScanText()
    {
        var ins = GameObject.FindObjectsOfType<TextEventFlag>();
        var obj = new List<GameObject>();
        for (int i = 0; i < ins.Length; i++)
        {
            obj.Add(ins[i].gameObject);
        }
        obj = _SortWithZ(obj);
        data.TextBlocks = new ParagraphData.TextBlock[obj.Count];
        for (int i = 0; i < obj.Count; i++)
        {
            data.TextBlocks[i] = new ParagraphData.TextBlock();
            data.TextBlocks[i].Position = obj[i].transform.position;
            var item = obj[i].GetComponent<TextEventFlag>();
            data.TextBlocks[i].Characters = item.block.Characters ;
            data.TextBlocks[i].Texts = item.block.Texts;
        }
    }
    private void ScanJobSelect()
    {
        var ins = GameObject.FindObjectsOfType<JobSelectFlag>();
        var obj = new List<GameObject>();
        for (int i = 0; i < ins.Length; i++)
        {
            obj.Add(ins[i].gameObject);
        }
        obj = _SortWithZ(obj);
        data.JobSelectBlocks = new ParagraphData.JobSelectBlock[obj.Count];
        for (int i = 0; i < obj.Count; i++)
        {
            data.JobSelectBlocks[i] = new ParagraphData.JobSelectBlock();
            data.JobSelectBlocks[i].Position = obj[i].transform.position;
        }
    }
}
#endif