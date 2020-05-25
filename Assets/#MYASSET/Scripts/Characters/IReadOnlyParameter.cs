using System;
using System.Collections.Generic;

public interface IReadOnlyParameter<T> where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
{
    T Value { get; }
    T DefaultVaule { get; }
    IReadOnlyDictionary<object, T> CorrectionDictionary { get; }

    T CorrectionVaule(object source);
}
