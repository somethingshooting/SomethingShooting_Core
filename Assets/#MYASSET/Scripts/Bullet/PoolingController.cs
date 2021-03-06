﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolingController : ManagerBase<PoolingController>
{
    private Dictionary<string, List<GameObject>> _PoolingObjectsDictionary = new Dictionary<string, List<GameObject>>();

    public IReadOnlyList<PoolObjct> PooledList => _PooledList;
    private List<PoolObjct> _PooledList = new List<PoolObjct>();

    /// <summary>
    /// (0, 0, 0)に生成する
    /// </summary>
    /// <param name="prefab">生成するゲームオブジェクト</param>
    /// <returns></returns>
    public GameObject Instantiate(GameObject prefab)
    {
        var pool = prefab.GetComponent<IPoolingObject>();
        if (pool == null)
        {
            return Object.Instantiate(prefab);
        }

        var poolObj = new PoolObjct(pool, prefab);
        var gameObj = TakeAtDictionary(poolObj);
        InitObject(gameObj);
        return gameObj;
    }

    public void Destroy(GameObject obj)
    {
        if (obj.GetComponent<IPoolingObject>() == null)
        {
            Destroy(obj);
            return;
        }

        ResetObject(obj);
        if (obj.activeSelf) obj.SetActive(false);
    }

    private void ResetObject(GameObject obj)
    {
        obj.transform.position = Vector3.zero;
        obj.transform.rotation = Quaternion.identity;
    }

    /// <summary> ゲームオブジェクトをアクティブにする </summary>
    /// <param name="obj"></param>
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
    /// <param name="obj">PoolingObjectのコード</param>
    /// <returns>アクティブ化したゲームオブジェクト</returns>
    private GameObject TakeAtDictionary(PoolObjct pool)
    {
        if (IsPooledObject(pool.PoolingObject.PoolingCode))
        {
            return TakeAtList(pool);
        }
        var objList = new List<GameObject>();
        _PoolingObjectsDictionary.Add(pool.PoolingObject.PoolingCode, objList);
        return TakeAtList(pool);
    }

    /// <summary> PoolingObjectかどうかを返す </summary>
    /// <param name="objCode">判定するコード</param>
    private bool IsPooledObject(string objCode)
    {
        if (PooledList.Any(pool => pool.PoolingObject.PoolingCode == objCode))
        {
            return true;
        }
        return false;
    }

    /// <summary> 待機状態のゲームオブジェクトを返す </summary>
    /// <param name="poolingObj"></param>
    /// <returns></returns>
    private GameObject TakeAtList(PoolObjct pool)
    {
        foreach (var item in _PoolingObjectsDictionary[pool.PoolingObject.PoolingCode])
        {
            if (item.activeSelf == false)
            {
                return item;
            }
        }
        return  AddPool(pool);
    }

    private GameObject AddPool(PoolObjct pool)
    {
        var poolObj = Instantiate(pool.PrefabObject, transform);
        if (poolObj.activeSelf == false)
        {
            poolObj.SetActive(true);
        }
        _PooledList.Add(pool);
        _PoolingObjectsDictionary[pool.PoolingObject.PoolingCode].Add(poolObj);
        return poolObj;
    }

    public class PoolObjct
    {
        public IPoolingObject PoolingObject { get; private set; }
        public GameObject PrefabObject { get; private set; }

        public PoolObjct(IPoolingObject poolingObject, GameObject gameObject)
        {
            PoolingObject = poolingObject;
            PrefabObject = gameObject;
        }
    }
}
