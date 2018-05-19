using System;

namespace ObjectDumper.Rules
{
    public class StringDumpRule : IDumpRule
    {
        public bool TryDump(object value, IDumper dumper, DumpOptions options)
        {
            if (!(value is string s))
                return false;

            var escaped = s.Replace("\n", "\\n").Replace("\r", "\\r").Replace("\t", "\\t").Replace("\b", "\\b").Replace("\"", "\\\"");
            string formatted;
            if (escaped.Length <= 80)
                formatted = "\"" + escaped + "\"";
            else
                formatted = "\"" + escaped.Substring(0, 80) + "\"...";

            int id = dumper.GetId(value, out _);
            dumper.WriteLine($"{formatted} [{dumper.GetNameOfType(typeof(string))}] #{id}");

            return true;
        }
    }
}
