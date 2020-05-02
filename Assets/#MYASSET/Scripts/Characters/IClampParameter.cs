using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IClampParameter<T> where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
{ 
    T Value { get; }
    T MaxValue { get; }
    T MinValue { get; }

    void AddValue(T value);
}
