using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ObjectDumper
{
    /// <summary>
    /// This class implements the core dumping algorithm.
    /// </summary>
    public static class Dumper
    {
        /// <summary>
        /// Dumps the specified value to the <see cref="TextWriter"/> using the
        /// specified <paramref name="name"/>.
        /// </summary>
        /// <param name="value">
        /// The value to dump to the <paramref name="writer"/>.
        /// </param>
        /// <param name="name">
        /// The name of the <paramref name="value"/> being dumped.
        /// </param>
        /// <param name="writer">
        /// The <see cref="TextWriter"/> to dump the <paramref name="value"/> to.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <para><paramref name="name"/> is <c>null</c> or empty.</para>
        /// <para>- or -</para>
        /// <para><paramref name="writer"/> is <c>null</c>.</para>
        /// </exception>
        public static void Dump(object value, string name, TextWriter writer)
        {
            if (StringEx.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");
            if (writer == null)
                throw new ArgumentNullException("writer");

            var lookup = new Dictionary<object, int>();
            InternalDump(0, name, value, writer, lookup, true);
        }

        private static void InternalDump(int indentationLevel, string name, object value, TextWriter writer, Dictionary<object, int> lookup, bool recursiveDump)
        {
            var indentation = new string(' ', indentationLevel * 3);

            if (value == null)
            {
                writer.WriteLine("{0}{1} = <null>", indentation, name);
                return;
            }

            Type type = value.GetType();

            // figure out if this is an object that has already been dumped, or is currently being dumped
            string keyRef = string.Empty;
            string keyPrefix = string.Empty;
            int key;
            if (!type.IsValueType)
            {
                if (lookup.TryGetValue(value, out key))
                    keyRef = string.Format(CultureInfo.InvariantCulture, " (see #{0})", key);
                else
                {
                    key = lookup.Count + 1;
                    lookup[value] = key;
                    keyPrefix = string.Format(CultureInfo.InvariantCulture, "#{0}: ", key);
                }
            }

            // work out how a simple dump of the value should be done
            bool isString = value is string;
            string typeName = value.GetType().FullName;
            string formattedValue = value.ToString();

            var exception = value as Exception;
            if (exception != null)
            {
                formattedValue = exception.GetType().Name + ": " + exception.Message;
            }

            if (formattedValue == typeName)
                formattedValue = string.Empty;
            else
            {
                // escape tabs and line feeds
                formattedValue = formattedValue.Replace("\t", "\\t").Replace("\n", "\\n").Replace("\r", "\\r");

                // chop at 80 characters
                int length = formattedValue.Length;
                if (length > 80)
                    formattedValue = formattedValue.Substring(0, 80);
                if (isString)
                    formattedValue = string.Format(CultureInfo.InvariantCulture, "\"{0}\"", formattedValue);
                if (length > 80)
                    formattedValue += " (+" + (length - 80) + " chars)";
                formattedValue = " = " + formattedValue;
            }

            writer.WriteLine("{0}{1}{2}{3} [{4}]{5}", indentation, keyPrefix, name, formattedValue, value.GetType(), keyRef);

            // Avoid dumping objects we've already dumped, or is already in the process of dumping
            if (keyRef.Length > 0)
                return;

            // don't dump strings, we already got at around 80 characters of those dumped
            if (isString)
                return;

            // don't dump value-types in the System namespace
            if (type.IsValueType && type.FullName == "System." + type.Name)
                return;

            if (!recursiveDump)
                return;

            PropertyInfo[] properties =
                (from property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                 where property.GetIndexParameters().Length == 0
                       && property.CanRead
                 select property).ToArray();
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).ToArray();

            if (properties.Length == 0 && fields.Length == 0)
                return;

            writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}{{", indentation));
            if (properties.Length > 0)
            {
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}   properties {{", indentation));
                foreach (PropertyInfo pi in properties)
                {
                    try
                    {
                        object propertyValue = pi.GetValue(value, null);
                        InternalDump(indentationLevel + 2, pi.Name, propertyValue, writer, lookup, true);
                    }
                    catch (TargetInvocationException ex)
                    {
                        InternalDump(indentationLevel + 2, pi.Name, ex, writer, lookup, false);
                    }
                }
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}   }}", indentation));
            }
            if (fields.Length > 0)
            {
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}   fields {{", indentation));
                foreach (FieldInfo field in fields)
                {
                    try
                    {
                        object fieldValue = field.GetValue(value);
                        InternalDump(indentationLevel + 2, field.Name, fieldValue, writer, lookup, true);
                    }
                    catch (TargetInvocationException ex)
                    {
                        InternalDump(indentationLevel + 2, field.Name, ex, writer, lookup, false);
                    }
                }
                writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}   }}", indentation));
            }
            writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}}}", indentation));
        }
    }
}