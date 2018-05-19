using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ObjectDumper
{
    /// <summary>
    /// This class implements IsNullOrWhiteSpace for .NET 3.5.
    /// </summary>
    internal static class StringEx
    {
        /// <summary>
        /// Compares the <paramref name="value"/> against <c>null</c> and checks if the
        /// string contains only whitespace.
        /// </summary>
        /// <param name="value">
        /// The string value to check.
        /// </param>
        /// <returns>
        /// <c>true</c> if the string <paramref name="value"/> is <c>null</c>, <see cref="string.Empty"/>,
        /// or contains only whitespace; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrWhiteSpace(string value)
        {
            return value == null || value.Trim().Length == 0;
        }
    }
}