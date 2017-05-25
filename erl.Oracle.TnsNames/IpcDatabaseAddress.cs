using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    [PublicAPI]
    public sealed class IpcDatabaseAddress : IDatabaseAddress
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IpcDatabaseAddress"/> class.
        /// </summary>
        /// <param name="protocol">The protocol.</param>
        /// <param name="key">The IPC key.</param>
        /// <param name="rawAddress"></param>
        public IpcDatabaseAddress([NotNull] string protocol, [NotNull] string key, [NotNull] string rawAddress)
        {
            Protocol = protocol ?? throw new ArgumentNullException(nameof(protocol));
            Key = key ?? throw new ArgumentNullException(nameof(key));
            RawAddress = rawAddress ?? throw new ArgumentNullException(nameof(rawAddress));
        }

        /// <inheritdoc />
        public string Protocol { get; }

        /// <inheritdoc />
        public string RawAddress { get; }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; }

        private string DebuggerDisplay => $"{Protocol}: {Key}";
    }
}