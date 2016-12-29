using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    public enum TnsNamesParseError
    {
        /// <summary>
        /// The invalid port range
        /// </summary>
        InvalidPortRange,
        /// <summary>
        /// The invalid port string
        /// </summary>
        InvalidPortString,
        /// <summary>
        /// The no database addresses
        /// </summary>
        NoDatabaseAddresses,
        /// <summary>
        /// The missing host
        /// </summary>
        MissingHost,
        /// <summary>
        /// The missing key
        /// </summary>
        MissingKey,
        /// <summary>
        /// The missing pipe
        /// </summary>
        MissingPipe,
        /// <summary>
        /// The missing port
        /// </summary>
        MissingPort,
        /// <summary>
        /// The missing protocol
        /// </summary>
        MissingProtocol,
        /// <summary>
        /// The missing server
        /// </summary>
        MissingServer,
        /// <summary>
        /// The missing service name
        /// </summary>
        MissingServiceName,
        /// <summary>
        /// The missing TNS name
        /// </summary>
        MissingTnsName
    }
}