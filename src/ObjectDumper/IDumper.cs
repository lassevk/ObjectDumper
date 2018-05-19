using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using JetBrains.Annotations;

namespace ObjectDumper
{
    public interface IDumper : IIdGenerator, ITypeNamer
    {
        void Dump([CanBeNull] object value, [CanBeNull] string name = null);
        void WriteLine([CanBeNull] string line);
    }

    internal class InternalDumper : IDumper
    {
        [CanBeNull]
        private string _Name;

        [NotNull]
        private readonly TextWriter _Writer;

        [NotNull]
        private readonly string _Indent;

        [NotNull]
        private readonly DumpOptions _Options;

        [NotNull, ItemNotNull]
        private readonly IEnumerable<IDumpRule> _Rules;

        [NotNull]
        private readonly IIdGenerator _IdGenerator;

        [NotNull]
        private readonly ProxyRules _ProxyRules;

        [NotNull]
        private readonly ITypeNamer _TypeNamer;

        public InternalDumper([CanBeNull] string name, [NotNull] TextWriter writer, [NotNull] string indent, [NotNull, ItemNotNull] IEnumerable<IDumpRule> rules, [NotNull] DumpOptions options, [NotNull] IIdGenerator idGenerator, [NotNull] ProxyRules proxyRules, [NotNull] ITypeNamer typeNamer)
        {
            _Name = name;
            _Writer = writer;
            _Indent = indent;
            _Options = options;
            _IdGenerator = idGenerator;
            _ProxyRules = proxyRules;
            _TypeNamer = typeNamer;
            _Rules = rules;
        }

        public static void Dump([CanBeNull] object value, [CanBeNull] string name, [NotNull] TextWriter writer, [NotNull] DumpOptions options, [NotNull] IEnumerable<IDumpRule> rules, [NotNull] ProxyRules proxyRules, [NotNull] ITypeNamer typeNamer)
        {
            var dumper = new InternalDumper(name, writer, String.Empty, rules, options, new IdGenerator(), proxyRules, typeNamer);
            dumper.Dump(value);
        }

        void IDumper.Dump([CanBeNull] object value, [CanBeNull] string name)
        {
            var nested = new InternalDumper(name, _Writer, _Indent + "  ", _Rules, _Options, _IdGenerator, _ProxyRules, _TypeNamer);
            nested.Dump(value);
        }

        private void Dump([CanBeNull] object value)
        {
            value = _ProxyRules.GetProxy(value);
            foreach (var rule in _Rules)
                if (rule.TryDump(value, this, _Options))
                    break;
        }

        public void WriteLine(string line)
        {
            if (line == null)
                return;

            if (_Name != null)
            {
                _Writer.WriteLine($"{_Indent}{_Name} : {line}");
                _Name = null;
                return;
            }

            _Writer.WriteLine($"{_Indent}{line}");
        }

        public int GetId(object instance, out bool isFirstOccurrence)
        {
            return _IdGenerator.GetId(instance, out isFirstOccurrence);
        }

        public string GetNameOfType(Type type)
        {
            return _TypeNamer.GetNameOfType(type);
        }
    }
}