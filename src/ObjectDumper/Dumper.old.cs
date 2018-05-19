using System;

namespace ObjectDumper
{
    public partial class Dumper
    {
        //private static void InternalDump(int indentationLevel, string name, object value, TextWriter writer, IIdGenerator idGenerator,bool recursiveDump, DumpOptions options)
        //{
        //    var indentation = new string(' ', indentationLevel * 3);

        //    if (value == null)
        //    {
        //        writer.WriteLine("{0}{1} = <null>", indentation, name);
        //        return;
        //    }

        //    Type type = value.GetType();

        //    // figure out if this is an object that has already been dumped, or is currently being dumped
        //    string keyRef = string.Empty;
        //    string keyPrefix = string.Empty;
        //    if (!type.IsValueType)
        //    {
        //        bool firstTime;
        //        long key = idGenerator.GetId(value, out firstTime);
        //        if (!firstTime)
        //            keyRef = string.Format(CultureInfo.InvariantCulture, " (see #{0})", key);
        //        else
        //        {
        //            keyPrefix = string.Format(CultureInfo.InvariantCulture, "#{0}: ", key);
        //        }
        //    }

        //    // work out how a simple dump of the value should be done
        //    bool isString = value is string;
        //    string typeName = value.GetType().FullName;
        //    string formattedValue = value.ToString();

        //    var exception = value as Exception;
        //    if (exception != null)
        //    {
        //        formattedValue = exception.GetType().Name + ": " + exception.Message;
        //    }

        //    if (formattedValue == typeName)
        //        formattedValue = string.Empty;
        //    else
        //    {
        //        // escape tabs and line feeds
        //        formattedValue = formattedValue.Replace("\t", "\\t").Replace("\n", "\\n").Replace("\r", "\\r");

        //        // chop at 80 characters
        //        //int length = formattedValue.Length;
        //        //if (length > 80)
        //        //    formattedValue = formattedValue.Substring(0, 80);
        //        if (isString)
        //            formattedValue = string.Format(CultureInfo.InvariantCulture, "\"{0}\"", formattedValue);
        //        //if (length > 80)
        //        //    formattedValue += " (+" + (length - 80) + " chars)";
        //        formattedValue = " = " + formattedValue;
        //    }

        //    //writer.WriteLine("{0}{1}{2}{3} [{4}]{5}", indentation, keyPrefix, name, formattedValue, value.GetType(), keyRef);
        //    writer.WriteLine("{0}{1}{2}{3} [{4}]", indentation, keyPrefix, name, formattedValue, keyRef);

        //    // Avoid dumping objects we've already dumped, or is already in the process of dumping
        //    if (keyRef.Length > 0)
        //        return;

        //    // don't dump strings, we already got at around 80 characters of those dumped
        //    if (isString)
        //        return;

        //    // don't dump value-types in the System namespace
        //    if (type.IsValueType && type.FullName == "System." + type.Name)
        //        return;

        //    // Avoid certain types that will result in endless recursion
        //    if (type.FullName == "System.Reflection." + type.Name)
        //        return;

        //    //if (value is System.Security.Principal.SecurityIdentifier)
        //    //    return;

        //    if (!recursiveDump)
        //        return;

        //    PropertyInfo[] properties =
        //        (from property in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
        //         where property.GetIndexParameters().Length == 0
        //               && property.CanRead
        //         select property).ToArray();
        //    IEnumerable<FieldInfo> fields = options.NoFields ? Enumerable.Empty<FieldInfo>() : type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        //    if (!properties.Any() && !fields.Any())
        //        return;

        //    writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}{{", indentation));
        //    if (properties.Any())
        //    {
        //        writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}   properties {{", indentation));
        //        foreach (PropertyInfo pi in properties)
        //        {
        //            try
        //            {
        //                object propertyValue = pi.GetValue(value, null);
        //                InternalDump(indentationLevel + 2, pi.Name, propertyValue, writer, idGenerator, true, options);
        //            }
        //            catch (TargetInvocationException ex)
        //            {
        //                InternalDump(indentationLevel + 2, pi.Name, ex, writer, idGenerator, false, options);
        //            }
        //            catch (ArgumentException ex)
        //            {
        //                InternalDump(indentationLevel + 2, pi.Name, ex, writer, idGenerator, false, options);
        //            }
        //            //catch (RemotingException ex)
        //            //{
        //            //    InternalDump(indentationLevel + 2, pi.Name, ex, writer, idGenerator, false, options);
        //            //}
        //        }
        //        writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}   }}", indentation));
        //    }
        //    if (fields.Any())
        //    {
        //        writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}   fields {{", indentation));
        //        foreach (FieldInfo field in fields)
        //        {
        //            try
        //            {
        //                object fieldValue = field.GetValue(value);
        //                InternalDump(indentationLevel + 2, field.Name, fieldValue, writer, idGenerator, true, options);
        //            }
        //            catch (TargetInvocationException ex)
        //            {
        //                InternalDump(indentationLevel + 2, field.Name, ex, writer, idGenerator, false, options);
        //            }
        //        }
        //        writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}   }}", indentation));
        //    }

        //    if (value is IEnumerable)
        //    {
        //        writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}   collections {{", indentation));

        //        foreach (var collectionItem in value as IEnumerable)
        //        {
        //            try
        //            {
        //                object fieldValue = collectionItem;
        //                InternalDump(indentationLevel + 2, "collectionItem", fieldValue, writer, idGenerator, true, options);
        //            }
        //            catch (TargetInvocationException ex)
        //            {
        //                InternalDump(indentationLevel + 2, "collectionItem", ex, writer, idGenerator, false, options);
        //            }
        //        }
        //    }


        //    writer.WriteLine(string.Format(CultureInfo.InvariantCulture, "{0}}}", indentation));
        //}
    }
}
