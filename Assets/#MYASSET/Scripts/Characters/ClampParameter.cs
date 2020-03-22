using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClampParameter
{
    public int Value => _Value;
    [SerializeField] private int _Value;

    public int MaxValue => _MaxValue;
    [SerializeField] private int _MaxValue;

    public int MinValue => _MinValue;
    [SerializeField] private int _MinValue;

    public ClampParameter(int value, int minValue, int maxValue)
    {
        _Value = value;
        _MinValue = minValue;
        _MaxValue = maxValue;
    }

    public void AddValue(int value)
    {
        var v = Value + value;
        _Value = Mathf.Clamp(v, MinValue, MaxValue);
    }
}
