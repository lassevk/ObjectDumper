using System;
using System.IO;

using JetBrains.Annotations;

namespace ObjectDumper
{
    [PublicAPI]
    public partial class Dumper
    {
        /// <summary>
        /// Gets the default <see cref="Dumper"/> instance.
        /// </summary>
        [NotNull]
        public static Dumper Default { get; } = new Dumper();

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
        public static void Dump([CanBeNull] object value, [CanBeNull] string name, [NotNull] TextWriter writer)
        {
            Dump(value, name, writer, DumpOptions.Default);
        }

        public static void Dump([CanBeNull] object value, [CanBeNull] string name, [NotNull] TextWriter writer, [CanBeNull] DumpOptions options)
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            Default.DumpStuff(value, name, writer, options ?? DumpOptions.Default);
        }
    }
}
