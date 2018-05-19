using System;

using JetBrains.Annotations;

namespace ObjectDumper
{
    public interface IWeightedRule
    {
        int Weight { get; }
        
        [NotNull]
        IDumpRule Rule { get; }
    }
}
