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
            Protocol = protocol ?? throw new ArgumentNullException(nameof(protocol));
            Server = server ?? throw new ArgumentNullException(nameof(server));
            Pipe = pipe ?? throw new ArgumentNullException(nameof(pipe));
            RawAddress = rawAddress ?? throw new ArgumentNullException(nameof(rawAddress));
        }

        /// <inheritdoc />
        public string Protocol { get; }

        /// <inheritdoc />
        public string RawAddress { get; }

        /// <summary>
        /// Gets the pipe.
        /// </summary>
        /// <value>
        /// The pipe.
        /// </value>
        public string Pipe { get; }

        /// <summary>
        /// Gets the server.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        public string Server { get; }

        private string DebuggerDisplay => $"{Protocol}: {Server} / {Pipe}";
    }
}