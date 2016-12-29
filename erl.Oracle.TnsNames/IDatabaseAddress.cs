using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    public interface IDatabaseAddress
    {
        /// <summary>
        /// Gets the protocol.
        /// </summary>
        /// <value>
        /// The protocol.
        /// </value>
        string Protocol { get; }

        /// <summary>
        /// Gets the raw address as represented in TNS names file.
        /// </summary>
        /// <value>
        /// The raw address from TNS names file.
        /// </value>
        string RawAddress { get; }
    }
}