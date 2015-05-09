using System;
using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    /// 
    /// </summary>
    public class UnknownDatabaseAddress : IDatabaseAddress
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="protocol"></param>
        /// <param name="rawAddress"></param>
        public UnknownDatabaseAddress([NotNull] string protocol, [NotNull] string rawAddress)
        {
            if (protocol == null) throw new ArgumentNullException("protocol");
            if (rawAddress == null) throw new ArgumentNullException("rawAddress");
            Protocol = protocol;
            RawAddress = rawAddress;
        }

        public string Protocol { get; private set; }
        public string RawAddress { get; private set; }
    }
}