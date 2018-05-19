using System;

using JetBrains.Annotations;

namespace ObjectDumper
{
    public interface ITypeNamer
    {
        [NotNull]
        string GetNameOfType([NotNull] Type type);
    }
}