using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Parameter
{
    public int Value => _Value;
    [SerializeField] private int _Value;

    public int DefaultVaule => _DefaultValue;
    [SerializeField] private int _DefaultValue;

    /// <summary> 補正値のリスト </summary>
    private Dictionary<object, int> _CorrectionList = new Dictionary<object, int>();

    // コンストラクタ
    public Parameter(int defaultVaule)
    {
        this._DefaultValue = defaultVaule;

        _CorrectionList = new Dictionary<object, int>();
    }

    public Parameter() : this(0) { }

    /// <summary> Vauleを更新する </summary>
    private void UpdateVaule()
    {
        var value = DefaultVaule;
        if (_CorrectionList.Count > 0)
        {
            foreach (var item in _CorrectionList)
            {
                value += item.Value;
            }
        }
    }

    /// <summary>
    /// 補正値を加算する
    /// </summary>
    /// <param name="source">この関数を呼び出しているクラス</param>
    /// <param name="value">加算する補正値</param>
    public void AddCorrection(object source, int value)
    {
        _CorrectionList.Add(source, value);
        UpdateVaule();
    }

    /// <summary>
    /// (非推奨) 補正値を加算する
    /// </summary>
    /// <param name="value">加算する補正値</param>
    public void AccCorrection(int value)
    {
        _CorrectionList.Add(null, value);
        UpdateVaule();
    }

    /// <summary>
    /// 補正値を取り除く
    /// </summary>
    /// <param name="source">加算したクラス</param>
    public void RemoveCorrection(object source)
    {
        _CorrectionList.Remove(source);
        UpdateVaule();
    }

    /// <summary>
    /// キーにより加算された補正値を返す
    /// </summary>
    /// <param name="source">検索するキー</param>
    /// <returns>補正値</returns>
    public int CorrectionVaule(object source)
    {
        return _CorrectionList[source];
    }
}
