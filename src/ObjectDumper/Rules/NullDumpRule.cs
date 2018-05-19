using System;

namespace ObjectDumper.Rules
{
    public class NullDumpRule : IDumpRule
    {
        public bool TryDump(object value, IDumper dumper, DumpOptions options)
        {
            if (ReferenceEquals(value, null))
            {
                dumper.WriteLine("null");
                return true;
            }

            return false;
        }
    }
}