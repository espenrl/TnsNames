using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    ///
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay, nq}")]
    [PublicAPI]
    public class UnknownDatabaseAddress : IDatabaseAddress
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="protocol"></param>
        /// <param name="rawAddress"></param>
        public UnknownDatabaseAddress([NotNull] string protocol, [NotNull] string rawAddress)
        {
            if (protocol == null) throw new ArgumentNullException(nameof(protocol));
            if (rawAddress == null) throw new ArgumentNullException(nameof(rawAddress));
            Protocol = protocol;
            RawAddress = rawAddress;
        }

        /// <inheritdoc />
        public string Protocol { get; }

        /// <inheritdoc />
        public string RawAddress { get; }

        private string DebuggerDisplay => $"{Protocol}: {RawAddress}";
    }
}