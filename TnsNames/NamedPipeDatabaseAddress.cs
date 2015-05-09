using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{

    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{Protocol,nq}: {Server,nq} / {Pipe,nq}")]
    public sealed class NamedPipeDatabaseAddress : IDatabaseAddress
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NamedPipeDatabaseAddress"/> class.
        /// </summary>
        /// <param name="protocol">The protocol.</param>
        /// <param name="server"></param>
        /// <param name="pipe"></param>
        /// <param name="rawAddress"></param>
        public NamedPipeDatabaseAddress([NotNull] string protocol, [NotNull] string server, [NotNull] string pipe, [NotNull] string rawAddress)
        {
            if (protocol == null) throw new ArgumentNullException("protocol");
            if (server == null) throw new ArgumentNullException("server");
            if (pipe == null) throw new ArgumentNullException("pipe");
            if (rawAddress == null) throw new ArgumentNullException("rawAddress");

            Protocol = protocol;
            Server = server;
            Pipe = pipe;
            RawAddress = rawAddress;
        }

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
        /// <summary>
        /// Gets the pipe.
        /// </summary>
        /// <value>
        /// The pipe.
        /// </value>
        public string Pipe { get; private set; }
        /// <summary>
        /// Gets the server.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        public string Server { get; private set; }
    }
}