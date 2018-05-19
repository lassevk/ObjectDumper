using System;
using System.Reflection;

namespace ObjectDumper.Rules
{
    public class BasicObjectDumpRule : IDumpRule
    {
        public bool TryDump(object value, IDumper dumper, DumpOptions options)
        {
            if (ReferenceEquals(value, null))
                return false;

            var type = value.GetType();
            dumper.WriteLine(dumper.GetNameOfType(type));
            dumper.WriteLine("{");

            foreach (var property in value.GetType().GetTypeInfo().GetProperties())
            {
                if (!property.CanRead)
                    continue;
                if (property.GetIndexParameters().Length > 0)
                    continue;

                var propertyValue = property.GetValue(value);
                dumper.Dump(propertyValue, property.Name);
            }

            dumper.WriteLine("}");

            return true;
        }
    }
}