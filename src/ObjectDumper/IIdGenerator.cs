using System;

using JetBrains.Annotations;

namespace ObjectDumper
{
    public interface IIdGenerator
    {
        int GetId([CanBeNull] object instance, out bool isFirstOccurrence);
    }
}