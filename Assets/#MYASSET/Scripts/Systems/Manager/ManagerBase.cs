﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] // ゲームオブジェクトに2つ以上このコンポーネントはアタッチできない
public abstract class ManagerBase<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T _Instance;
    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<T>();
            }

            return _Instance;
        }
    }
}
