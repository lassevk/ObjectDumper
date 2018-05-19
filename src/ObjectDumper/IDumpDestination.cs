using System;

using JetBrains.Annotations;

namespace ObjectDumper
{
    public interface IDumpDestination
    {
        void WriteLine([NotNull] string line);

        [NotNull]
        IDumpDestination CreateNestedDestination();
    }
}