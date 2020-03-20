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
    {
        var data = ScriptableObject.CreateInstance(typeof(QuestData)) as QuestData;
        AssetDatabase.CreateAsset(data, "Assets/#MYASSET/Scripts/Systems/QuestData"+_Name+".asset");
        GameObject[] objects = SortWithZ(GameObject.FindGameObjectsWithTag("Enemy"));
        data.Enemies = new QuestData.EnemyData[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            QuestData.EnemyData enemy = data.Enemies[i];
            enemy.Position = objects[i].transform.position;
            enemy.Prefab = PrefabUtility.GetCorrespondingObjectFromSource(objects[i]);
            if (objects[i].GetComponent<QuestFlagObject>() != null)
                enemy.Frag = true;
            else
                enemy.Frag = false;
        }
    }
    
    GameObject[] SortWithZ(GameObject[] objects)
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
