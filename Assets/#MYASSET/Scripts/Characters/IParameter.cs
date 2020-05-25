using System;
using System.Collections.Generic;

public interface IParameter<T> where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
{
    T Value { get; }
    T DefaultVaule { get; }
    IReadOnlyDictionary<object, T> CorrectionDictionary { get; }

    void SetDefaultValue(T value);
    void AddCorrection(object source, T value);
    void RemoveCorrection(object source);
    T CorrectionVaule(object source);
}
