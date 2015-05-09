using System;
using System.Diagnostics;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    /// Info about a TNS names file.
    /// </summary>
    [DebuggerDisplay("{System.Enum.GetName(typeof(TnsNamesSource), Source),nq} : {Filepath}")]
    public sealed class TnsNamesFileInfo
    {
        internal TnsNamesFileInfo(string filepath, TnsNamesSource source, TnsNamesFileInfo parent = null, int sourceOrder = 1)
        {
            if (filepath == null) throw new ArgumentNullException("filepath");

            Filepath = filepath;
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
        public TnsNamesFileInfo Parent { get; private set; }
        /// <summary>
        /// Gets the filepath of the TNS names file.
        /// </summary>
        /// <value>
        /// The filepath.
        /// </value>
        public string Filepath { get; private set; }
        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public TnsNamesSource Source { get; private set; }
        /// <summary>
        /// Gets the source order.
        /// </summary>
        /// <value>
        /// The source order.
        /// </value>
        public int SourceOrder { get; private set; }
    }
}