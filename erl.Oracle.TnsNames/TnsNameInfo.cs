using System.Diagnostics;
using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    /// Info about a TNS name.
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    [PublicAPI]
    public sealed class TnsNameInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TnsNameInfo"/> class.
        /// </summary>
        /// <param name="tnsName">The TNS name.</param>
        /// <param name="description">The raw description parameter from TNS names file.</param>
        /// <param name="serviceName">The service name.</param>
        /// <param name="databaseAddresses">The database addresses.</param>
        public TnsNameInfo(string tnsName, string description, string serviceName, IDatabaseAddress[] databaseAddresses)
        {
            TnsName = tnsName;
            Description = description;
            ServiceName = serviceName;
            DatabaseAddresses = databaseAddresses;
        }

        /// <summary>
        /// Gets the TNS name.
        /// </summary>
        /// <value>
        /// The TNS name.
        /// </value>
        public string TnsName { get; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The raw description parameter from TNS names file.
        /// </value>
        public string Description { get; }

        /// <summary>
        /// Gets the datasource for connect string usage.
        /// </summary>
        /// <value>
        /// The datasource.
        /// </value>
        public string DataSource => $"({Description})";


        /// <summary>
        /// Gets the service name.
        /// </summary>
        /// <value>
        /// The service name.
        /// </value>
        public string ServiceName { get; }

        /// <summary>
        /// Gets the database addresses.
        /// </summary>
        /// <value>
        /// The database addresses.
        /// </value>
        public IDatabaseAddress[] DatabaseAddresses { get; }

        /// <summary>
        /// Gets the TNS names source file.
        /// </summary>
        /// <value>
        /// The TNS names source file.
        /// </value>
        public TnsNamesFile Source { get; internal set; }

        #region Equality by TnsName

        private bool Equals(TnsNameInfo other)
        {
            return string.Equals(TnsName, other.TnsName);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((TnsNameInfo)obj);
        }

        public override int GetHashCode()
        {
            return TnsName?.GetHashCode() ?? 0;
        }

        #endregion

        private string DebuggerDisplay => TnsName;
    }
}