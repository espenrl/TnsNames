using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{Protocol,nq}: {Key,nq}")]
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
            if (protocol == null) throw new ArgumentNullException("protocol");
            if (key == null) throw new ArgumentNullException("key");
            if (rawAddress == null) throw new ArgumentNullException("rawAddress");
            Protocol = protocol;
            Key = key;
            RawAddress = rawAddress;
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; private set; }
        /// <summary>
        /// Gets the protocol.
        /// </summary>
        /// <value>
        /// The protocol.
        /// </value>
        public string Protocol { get; private set; }
        /// <summary>
        /// Gets the raw address as represented in TNS names file.
        /// </summary>
        /// <value>
        /// The raw address from TNS names file.
        /// </value>
        public string RawAddress { get; private set; }
    }
}