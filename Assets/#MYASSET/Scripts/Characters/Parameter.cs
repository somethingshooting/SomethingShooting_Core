﻿using System;
using System.Collections.Generic;
using UniRx;

[Serializable]
public class Parameter
{
    public int Value { get; private set; }

    public int DefaultVaule { get; private set; }

    /// <summary> 補正値のリスト </summary>
    private ReactiveProperty<Dictionary<object, int>> _CorrectionList = new ReactiveProperty<Dictionary<object, int>>();

    // コンストラクタ
    public Parameter(int defaultVaule)
    {
        this.DefaultVaule = defaultVaule;

        _CorrectionList
            .Subscribe(_ => UpdateVaule());
    }

    public Parameter() : this(0) { }

    /// <summary> Vauleを更新する </summary>
    private void UpdateVaule()
    {
        var value = DefaultVaule;
        foreach (var item in _CorrectionList.Value)
        {
            value += item.Value;
        }
    }

    /// <summary>
    /// 補正値を加算する
    /// </summary>
    /// <param name="source">この関数を呼び出しているクラス</param>
    /// <param name="value">加算する補正値</param>
    public void AddCorrection(object source, int value)
    {
        _CorrectionList.Value.Add(source, value);
    }

    /// <summary>
    /// (非推奨) 補正値を加算する
    /// </summary>
    /// <param name="value">加算する補正値</param>
    public void AccCorrection(int value)
    {
        _CorrectionList.Value.Add(null, value);
    }

    /// <summary>
    /// 補正値を取り除く
    /// </summary>
    /// <param name="source">加算したクラス</param>
    public void RemoveCorrection(object source)
    {
        _CorrectionList.Value.Remove(source);
    }

    /// <summary>
    /// キーにより加算された補正値を返す
    /// </summary>
    /// <param name="source">検索するキー</param>
    /// <returns>補正値</returns>
    public int CorrectionVaule(object source)
    {
        return _CorrectionList.Value[source];
    }
}
