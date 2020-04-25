using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingController : ManagerBase<PoolingController>
{
    private Dictionary<GameObject, List<GameObject>> _PoolingObjList = new Dictionary<GameObject, List<GameObject>>();

    public IReadOnlyList<GameObject> PooledObjList => _PooledObjList;
    private List<GameObject> _PooledObjList = new List<GameObject>();

    /// <summary>
    /// (0, 0, 0)に生成する
    /// </summary>
    /// <param name="obj">生成するゲームオブジェクト</param>
    /// <returns></returns>
    public GameObject Instantiate(GameObject obj)
    {
        if (obj.GetComponent<IPoolingObject>() == null) { return Object.Instantiate(obj); }
        var gameObj = TakeAtDictionary(obj);
        InitObject(gameObj);
        return gameObj;
    }

    public void Destroy(GameObject obj)
    {
        if (obj.GetComponent<IPoolingObject>() == null) { Destroy(obj); }
        ResetObject(obj);
        if (obj.activeSelf) obj.SetActive(false);
    }

    private void ResetObject(GameObject obj)
    {
        obj.transform.position = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
    }

    private void InitObject(GameObject obj)
    {
        if (obj.activeSelf == false)
        {
            obj.SetActive(true);
        }
    }

    /// <summary>
    /// 非アクティブのゲームオブジェクトをアクティブにして返す
    /// </summary>
    /// <param name="obj">プレハブのゲームオブジェクト</param>
    /// <returns></returns>
    private GameObject TakeAtDictionary(GameObject obj)
    {
        if (IsPooledObject(obj))
        {
            return TakeAtList(obj, _PoolingObjList[obj]);
        }
        var objList = new List<GameObject>();
        _PoolingObjList.Add(obj, objList);
        return TakeAtList(obj, objList);
    }

    private bool IsPooledObject(GameObject obj)
    {
        foreach (var item in PooledObjList)
        {
            if (item == obj)
            {
                return true;
            }
        }
        return false;
    }

    private GameObject TakeAtList(GameObject obj, List<GameObject> list)
    {
        foreach (var item in list)
        {
            if (item.activeSelf == false)
            {
                return item;
            }
        }
        return  AddPool(obj, list);
    }

    private GameObject AddPool(GameObject obj, List<GameObject> list)
    {
        var pooledObj = Instantiate(obj, transform);
        if (pooledObj.activeSelf == false)
        {
            pooledObj.SetActive(true);
        }
        list.Add(pooledObj);
        return pooledObj;
    }
}
