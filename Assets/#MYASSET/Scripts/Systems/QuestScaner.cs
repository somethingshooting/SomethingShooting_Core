using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class QuestScaner : MonoBehaviour
{
    [SerializeField]
    private string _Name;
    // Start is called before the first frame update
    void Start()
    {/*
        var data = ScriptableObject.CreateInstance(typeof(QuestData)) as QuestData;
        AssetDatabase.CreateAsset(data, "Assets/#MYASSET/Scripts/Systems/QuestData/"+_Name+".asset");
        GameObject[] objects = _SortWithZ(GameObject.FindGameObjectsWithTag("Enemy"));
        data.Enemies = new QuestData.EnemyData[objects.Length];
        int flagcount = 0;
        for (int i = 0; i < objects.Length; i++)
        {
            data.Enemies[i] = new QuestData.EnemyData();
            data.Enemies[i].Position = objects[i].transform.position;
            data.Enemies[i].Prefab = PrefabUtility.GetCorrespondingObjectFromSource(objects[i]);
            if (objects[i].GetComponent<QuestFlagObject>() != null)
            {
                data.Enemies[i].Flag = true;
                flagcount++;
            }
            else
                data.Enemies[i].Flag = false;
        }
            data.FlagCount = flagcount;*/
    }

    [ContextMenu("ScanQuest")]
    private void _Scan()
    {
        var data = ScriptableObject.CreateInstance(typeof(QuestData)) as QuestData;
        AssetDatabase.CreateAsset(data, "Assets/#MYASSET/Scripts/Systems/QuestData/" + _Name + ".asset");
        GameObject[] objects = _SortWithZ(GameObject.FindGameObjectsWithTag("Enemy"));
        data.Enemies = new QuestData.EnemyData[objects.Length];
        int flagcount = 0;
        for (int i = 0; i < objects.Length; i++)
        {
            data.Enemies[i] = new QuestData.EnemyData();
            data.Enemies[i].Position = objects[i].transform.position;
            data.Enemies[i].Prefab = PrefabUtility.GetCorrespondingObjectFromSource(objects[i]);
            if (objects[i].GetComponent<QuestFlagObject>() != null)
            {
                data.Enemies[i].Flag = true;
                flagcount++;
            }
            else
                data.Enemies[i].Flag = false;
        }
        data.FlagCount = flagcount;
    }
    
    private GameObject[] _SortWithZ(GameObject[] objects)
    {
        GameObject[] sortobjects = new GameObject[objects.Length];
        List<GameObject> subobjects = new List<GameObject>();
        subobjects.AddRange(objects);
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject min = subobjects[0];
            for (int g = 0; g < subobjects.Count; g++)
            {
                if (subobjects[g].transform.position.z <= min.transform.position.z)
                    min = subobjects[g];
            }
            sortobjects[i] = min;
            subobjects.Remove(min);
        }


        return sortobjects;
    }
}
