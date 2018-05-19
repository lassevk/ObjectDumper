using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace ObjectDumper.Rules
{
    public class ReflectionDumpRule : IDumpRule
    {
        public bool TryDump(object value, IDumper dumper, DumpOptions options)
        {
            if (value is MethodInfo m)
                return TryDumpMethodInfo(m, dumper, options);

            if (value is Module mo)
                return TryDumpModule(mo, dumper, options);

            if (value is Assembly a)
                return TryDumpAssembly(a, dumper, options);

            return false;
        }

        private bool TryDumpAssembly([NotNull] Assembly assembly, [NotNull] IDumper dumper, [NotNull] DumpOptions options)
        {
            if (dumper.WriteTypeLine(assembly))
                return true;

            dumper.WriteLine("{");
            dumper.Dump(assembly.Location, nameof(assembly.Location));
            dumper.Dump(assembly.FullName, nameof(assembly.FullName));
            dumper.WriteLine("}");
            return true;
        }

        private bool TryDumpModule([NotNull] Module mo, [NotNull] IDumper dumper, [NotNull] DumpOptions options)
        {
            dumper.WriteLine($"module \"{mo.Name}\"");
            return true;
        }

        private bool TryDumpMethodInfo([NotNull] MethodInfo methodInfo, [NotNull] IDumper dumper, [NotNull] DumpOptions options)
        {
            
            dumper.WriteLine(dumper.GetNameOfType(methodInfo.DeclaringType) + "." + methodInfo.Name);
            return true;
        }
    }
}
