using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ObjectDumper.Rules
{
    public class BasicTypeDumpRule : IDumpRule
    {
        public bool TryDump(object value, IDumper dumper, DumpOptions options)
        {
            if (value == null)
                return false;

            string typeSuffix = $" [{dumper.GetNameOfType(value.GetType())}]";
            switch (value)
            {
                case short s:
                case ushort us:
                case byte b:
                case sbyte sb:
                case long l:
                case ulong ul:
                case int i:
                case uint ui:
                case decimal de:
                    dumper.WriteLine(((IFormattable)value).ToString("G", CultureInfo.InvariantCulture) + typeSuffix);
                    return true;

                case double d:
                case float f:
                    dumper.WriteLine(((IFormattable)value).ToString("R19", CultureInfo.InvariantCulture) + typeSuffix);
                    return true;

                default:
                    return false;
            }
        }
    }
}