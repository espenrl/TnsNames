using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    /// Database address for a TNS name.
    /// </summary>
    [DebuggerDisplay("{Protocol,nq}: {Host,nq} {Port,nq}")]
    public sealed class IpDatabaseAddress : IDatabaseAddress
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IpDatabaseAddress"/> class.
        /// </summary>
        /// <param name="protocol">The protocol.</param>
        /// <param name="host">The host.</param>
        /// <param name="port">The port.</param>
        /// <param name="rawAddress"></param>
        public IpDatabaseAddress([NotNull] string protocol, [NotNull] string host, int port, [NotNull] string rawAddress)
        {
            if (protocol == null) throw new ArgumentNullException("protocol");
            if (host == null) throw new ArgumentNullException("host");
            if (port < 1 || port > 65535) throw new ArgumentOutOfRangeException("port", port, "Port should be in range 1-65535.");
            if (rawAddress == null) throw new ArgumentNullException("rawAddress");
            Protocol = protocol;
            Host = host;
            Port = port;
            RawAddress = rawAddress;
        }

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host { get; private set; }
        /// <summary>
        /// Gets the port number.
        /// </summary>
        /// <value>
        /// The port number.
        /// </value>
        public int Port { get; private set; }

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