using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClampParameter<T> : IReadOnlyClampParameter<T>, IClampParameter<T> where T: IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable, new()
{
    public T Value => _Value;
    [SerializeField] private T _Value;

    public T MaxValue => _MaxValue;
    [SerializeField] private T _MaxValue;

    public T MinValue => _MinValue;
    [SerializeField] private T _MinValue;

    public ClampParameter(T value, T minValue, T maxValue)
    {
        _Value = value;
        _MinValue = minValue;
        _MaxValue = maxValue;
    }

    public void AddValue(T value)
    {
        var v = (dynamic)Value + value;
        _Value = Mathf.Clamp(v, (dynamic)MinValue, (dynamic)MaxValue);
    }
}
