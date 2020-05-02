using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Parameter<T> : IReadOnlyParameter<T>, IParameter<T> where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable, new()
{
    public T Value => _Value;
    [SerializeField] private T _Value;

    public T DefaultVaule => _DefaultValue;
    [SerializeField] private T _DefaultValue;

    public IReadOnlyDictionary<object, T> CorrectionDictionary => _CorrectionDictionary;
    /// <summary> 補正値のリスト </summary>
    private Dictionary<object, T> _CorrectionDictionary = new Dictionary<object, T>();

    // コンストラクタ
    public Parameter(T defaultVaule)
    {
        this._DefaultValue = defaultVaule;

        _CorrectionDictionary = new Dictionary<object, T>();
    }

    public Parameter() : this(new T()) { }

    /// <summary>
    /// （非推奨）DefaultVauleを変更する
    /// </summary>
    /// <param name="value">変更する値</param>
    public void SetDefaultValue(T value)
    {
        _DefaultValue = value;
        UpdateVaule();
    }

    /// <summary> Vauleを更新する </summary>
    private void UpdateVaule()
    {
        var value = DefaultVaule;
        if (_CorrectionDictionary.Count > 0)
        {
            foreach (var item in _CorrectionDictionary.Values)
            {
                value += (dynamic)item;
            }
        }
    }

    /// <summary>
    /// 補正値を加算する
    /// </summary>
    /// <param name="source">この関数を呼び出しているクラス</param>
    /// <param name="value">加算する補正値</param>
    public void AddCorrection(object source, T value)
    {
        _CorrectionDictionary.Add(source, value);
        UpdateVaule();
    }

    /// <summary>
    /// (非推奨) 補正値を加算する
    /// </summary>
    /// <param name="value">加算する補正値</param>
    public void AccCorrection(T value)
    {
        _CorrectionDictionary.Add(null, value);
        UpdateVaule();
    }

    /// <summary>
    /// 補正値を取り除く
    /// </summary>
    /// <param name="source">加算したクラス</param>
    public void RemoveCorrection(object source)
    {
        _CorrectionDictionary.Remove(source);
        UpdateVaule();
    }

    /// <summary>
    /// キーにより加算された補正値を返す
    /// </summary>
    /// <param name="source">検索するキー</param>
    /// <returns>補正値</returns>
    public T CorrectionVaule(object source)
    {
        return _CorrectionDictionary[source];
    }
}