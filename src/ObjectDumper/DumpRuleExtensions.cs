using System;

using JetBrains.Annotations;

namespace ObjectDumper
{
    public static class DumpRuleExtensions
    {
        [NotNull]
        public static IWeightedRule WithWeight([NotNull] this IDumpRule rule, int weight) => new WeightedRule(rule, weight);
    }
}