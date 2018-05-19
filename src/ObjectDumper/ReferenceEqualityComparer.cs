using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ObjectDumper
{
    internal class ReferenceEqualityComparer : IEqualityComparer<object>
    {
        bool IEqualityComparer<object>.Equals(object x, object y) => ReferenceEquals(x, y);
        int IEqualityComparer<object>.GetHashCode(object obj) => RuntimeHelpers.GetHashCode(obj);
    }
}