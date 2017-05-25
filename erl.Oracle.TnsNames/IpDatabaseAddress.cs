using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    /// Database address for a TNS name.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    [PublicAPI]
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
            if (port < 1 || port > 65535) throw new ArgumentOutOfRangeException(nameof(port), port, "Port should be in range 1-65535.");
            Protocol = protocol ?? throw new ArgumentNullException(nameof(protocol));
            Host = host ?? throw new ArgumentNullException(nameof(host));
            Port = port;
            RawAddress = rawAddress ?? throw new ArgumentNullException(nameof(rawAddress));
        }

        /// <inheritdoc />
        public string Protocol { get; }

        /// <inheritdoc />
        public string RawAddress { get; }

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host { get; }

        /// <summary>
        /// Gets the port number.
        /// </summary>
        /// <value>
        /// The port number.
        /// </value>
        public int Port { get; }

        private string DebuggerDisplay => $"{Protocol}: {Host} {Port}";
    }
}