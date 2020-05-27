using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolingObject
{
    //これが一致するゲームオブジェクトは同一とみなされる
    string PoolingCode { get; }

    void PoolingStart();
}
