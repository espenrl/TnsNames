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
    public class UnknownDatabaseAddress : IDatabaseAddress
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="protocol"></param>
        /// <param name="rawAddress"></param>
        public UnknownDatabaseAddress([NotNull] string protocol, [NotNull] string rawAddress)
        {
            Protocol = protocol ?? throw new ArgumentNullException(nameof(protocol));
            RawAddress = rawAddress ?? throw new ArgumentNullException(nameof(rawAddress));
        }

        /// <inheritdoc />
        public string Protocol { get; }

        /// <inheritdoc />
        public string RawAddress { get; }

        private string DebuggerDisplay => $"{Protocol}: {RawAddress}";
    }
}