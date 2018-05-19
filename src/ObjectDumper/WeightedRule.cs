using System;

using JetBrains.Annotations;

namespace ObjectDumper
{
    internal class WeightedRule : IWeightedRule
    {
        public WeightedRule([NotNull] IDumpRule rule, int weight)
        {
            Rule = rule ?? throw new ArgumentNullException(nameof(rule));
            Weight = weight;
        }

        public IDumpRule Rule { get; }

        public int Weight { get; }
    }
}