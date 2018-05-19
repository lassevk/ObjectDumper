using System;

using JetBrains.Annotations;

namespace ObjectDumper
{
    public interface IDumpRule
    {
        bool TryDump([CanBeNull] object value, [NotNull] IDumper dumper, [NotNull] DumpOptions options);
    }
}