using System;

namespace ObjectDumper
{
    /// <summary>
    /// Options for the <see cref="ObjectDumper"/>.
    /// </summary>
    public class DumpOptions
    {
        /// <summary>
        /// Gets the default <see cref="DumpOptions"/>.
        /// </summary>
        public static readonly DumpOptions Default = new DumpOptions();

        /// <summary>
        /// Gets or sets a value indicating whether to include public fields or not. Defaults to <c>true</c>.
        /// </summary>
        public bool IncludeFields { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether to ignore public fields. Defaults to <c>false</c>. 
        /// </summary>
        [Obsolete("Switch to using IncludeFields with a positive attitude")]
        public bool NoFields
        {
            get => !IncludeFields;
            set => IncludeFields = !value;
        }
    }
}