using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    /// Content of a TNS names file.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    [PublicAPI]
    public sealed class TnsNamesFile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TnsNamesFile"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="iFileEntries">The iFile entries.</param>
        /// <param name="tnsNames">The TNS name entries.</param>
        /// <exception cref="System.ArgumentNullException">
        /// info
        /// or
        /// iFileEntries
        /// or
        /// tnsNames
        /// </exception>
        public TnsNamesFile(TnsNamesFileInfo info, [NotNull] TnsNamesFileInfo[] iFileEntries, [NotNull] TnsNameInfo[] tnsNames)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));

            Parent = info.Parent;
            Filepath = info.Filepath;
            Source = info.Source;
            SourceOrder = info.SourceOrder;
            TnsNames = tnsNames ?? throw new ArgumentNullException(nameof(tnsNames));
            IfileEntries = iFileEntries ?? throw new ArgumentNullException(nameof(iFileEntries));

            foreach (var tnsNameInfo in tnsNames)
            {
                tnsNameInfo.Source = this;
            }
        }

        /// <summary>
        /// Gets the parent TNS names file (can be null).
        /// </summary>
        /// <value>
        /// The parent TNS names file.
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

        /// <summary>
        /// Gets the TNS names.
        /// </summary>
        /// <value>
        /// The TNS names.
        /// </value>
        public TnsNameInfo[] TnsNames { get; }

        /// <summary>
        /// Gets the iFile entries.
        /// </summary>
        /// <value>
        /// The iFile entries.
        /// </value>
        public TnsNamesFileInfo[] IfileEntries { get; }

        private string DebuggerDisplay => $"{Enum.GetName(typeof(TnsNamesSource), Source)} : {Filepath}";
    }
}