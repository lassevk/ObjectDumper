using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectDumper.Rules
{
    public class ExceptionDumpRule : IDumpRule
    {
        public bool TryDump(object value, IDumper dumper, DumpOptions options)
        {
            if (!(value is Exception ex))
                return false;

            if (dumper.WriteTypeLine(value))
                return true;

            dumper.WriteLine("{");
            dumper.WriteLine("}");
            return true;
        }
    }
}
