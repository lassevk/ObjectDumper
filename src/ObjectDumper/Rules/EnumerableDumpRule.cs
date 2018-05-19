using System;
using System.Collections;

namespace ObjectDumper.Rules
{
    public class EnumerableDumpRule : IDumpRule
    {
        public bool TryDump(object value, IDumper dumper, DumpOptions options)
        {
            if (!(value is IEnumerable e))
                return false;

            string typeName = "IEnumerable"; // TODO: Find generic type as well
            int id = dumper.GetId(value, out bool isFirstOccurrence);
            dumper.WriteLine($"[{typeName}] #{id}{(isFirstOccurrence ? " - already dumped" : "")}");
            if (isFirstOccurrence)
                return true;

            dumper.WriteLine("{");
            int index = 0;
            foreach (var element in e)
            {
                dumper.Dump(element, "#" + index);
                index++;
            }

            dumper.WriteLine("}");
            return true;
        }
    }
}