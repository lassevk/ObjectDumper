using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using JetBrains.Annotations;

using ObjectDumper.Rules;

namespace ObjectDumper
{
    /// <summary>
    /// This class allows you to dump a textual description of an object from an object instance.
    /// </summary>
    public partial class Dumper
    {
        public Dumper()
        {
            Rules.Add(new NullDumpRule().WithWeight(int.MaxValue));
            Rules.Add(new BasicTypeDumpRule().WithWeight(100));
            Rules.Add(new StringDumpRule().WithWeight(100));
            Rules.Add(new EnumerableDumpRule().WithWeight(100));
            Rules.Add(new BasicObjectDumpRule().WithWeight(0));
        }

        // TODO: Add class for this, similar to ProxyRules
        [NotNull, ItemNotNull]
        public List<IWeightedRule> Rules { get; } = new List<IWeightedRule>();
        
        [NotNull]
        public ProxyRules ProxyRules { get; } = new ProxyRules();

        // TODO: Figure out proper name for this
        public void DumpStuff(object value, string name, [NotNull] TextWriter writer, [CanBeNull] DumpOptions options)
        {
            var orderedRules = Rules.OrderByDescending(wr => wr.Weight).Select(wr => wr.Rule).ToList();
            InternalDumper.Dump(value, name, writer, options ?? DumpOptions.Default, orderedRules, ProxyRules, new CSharpTypeNamer());
        }
    }
}