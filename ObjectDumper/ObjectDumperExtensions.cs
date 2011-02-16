using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace ObjectDumper
{
    /// <summary>
    /// This class adds extension methods to all types to facilitate dumping of
    /// object contents to various outputs.
    /// </summary>
    public static class ObjectDumperExtensions
    {
        /// <summary>
        /// Dumps the contents of the specified <paramref name="value"/> to the
        /// <see cref="Debug"/> output.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object to dump.
        /// </typeparam>
        /// <param name="value">
        /// The object to dump.
        /// </param>
        /// <param name="name">
        /// The name to give to the object in the dump;
        /// or <c>null</c> to use a generated name.
        /// </param>
        /// <returns>
        /// The <paramref name="value"/>, to facilitate easy usage in expressions and method calls.
        /// </returns>
        public static T Dump<T>(this T value, string name = null)
        {
            Debug.WriteLine(name + " = " + value);
            return value;
        }

        /// <summary>
        /// Dumps the contents of the specified <paramref name="value"/> to a file
        /// with the specified <paramref name="filename"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object to dump.
        /// </typeparam>
        /// <param name="value">
        /// The object to dump.
        /// </param>
        /// <param name="filename">
        /// The full path to and name of the file to dump the object contents to.
        /// </param>
        /// <param name="name">
        /// The name to give to the object in the dump;
        /// or <c>null</c> to use a generated name.
        /// </param>
        /// <param name="encoding">
        /// The <see cref="Encoding"/> to use for the file;
        /// or <c>null</c> to use <see cref="Encoding.Default"/>.
        /// </param>
        /// <returns>
        /// The <paramref name="value"/>, to facilitate easy usage in expressions and method calls.
        /// </returns>
        public static T Dump<T>(this T value, string filename, string name = null, Encoding encoding = null)
        {
            return value;
        }

        /// <summary>
        /// Dumps the contents of the specified <paramref name="value"/> to
        /// the specified <paramref name="writer"/>.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object to dump.
        /// </typeparam>
        /// <param name="value">
        /// The object to dump.
        /// </param>
        /// <param name="writer">
        /// The <see cref="TextWriter"/> to dump the object contents to.
        /// </param>
        /// <param name="name">
        /// The name to give to the object in the dump;
        /// or <c>null</c> to use a generated name.
        /// </param>
        /// <returns>
        /// The <paramref name="value"/>, to facilitate easy usage in expressions and method calls.
        /// </returns>
        public static T Dump<T>(this T value, TextWriter writer, string name = null)
        {
            return value;
        }

        /// <summary>
        /// Dumps the contents of the specified <paramref name="value"/> and
        /// returns the dumped contents as a string.
        /// </summary>
        /// <typeparam name="T">
        /// The type of object to dump.
        /// </typeparam>
        /// <param name="value">
        /// The object to dump.
        /// </param>
        /// <param name="name">
        /// The name to give to the object in the dump;
        /// or <c>null</c> to use a generated name.
        /// </param>
        /// <returns>
        /// The dumped contents of the object.
        /// </returns>
        public static string DumpToString<T>(this T value, string name = null)
        {
            using (var writer = new StringWriter(CultureInfo.InvariantCulture))
            {
                Dump(value, writer, name);
                return writer.ToString();
            }
        }
    }
}