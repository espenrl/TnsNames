using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    /// Info about a TNS names file.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    [PublicAPI]
    public sealed class TnsNamesFileInfo
    {
        public TnsNamesFileInfo(string filepath, TnsNamesSource source, TnsNamesFileInfo parent = null, int sourceOrder = 1)
        {
            Filepath = filepath ?? throw new ArgumentNullException(nameof(filepath));
            Source = source;
            SourceOrder = sourceOrder;
            Parent = parent;
        }

        /// <summary>
        /// Gets the parent TNS names file info (can be null).
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        public TnsNamesFileInfo Parent { get; }

        /// <summary>
        /// Gets the filepath of the TNS names file.
        /// </summary>
        /// <value>
        /// The filepath.
        /// </value>
        public string Filepath { get; }

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public TnsNamesSource Source { get; }

        /// <summary>
        /// Gets the source order.
        /// </summary>
        /// <value>
        /// The source order.
        /// </value>
        public int SourceOrder { get; }

        private string DebuggerDisplay => $"{Enum.GetName(typeof(TnsNamesSource), Source)} : {Filepath}";
    }
}