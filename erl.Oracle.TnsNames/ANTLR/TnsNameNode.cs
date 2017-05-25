using System;
using System.Diagnostics;
using JetBrains.Annotations;

#pragma warning disable 1591 // Missing comments

namespace erl.Oracle.TnsNames.ANTLR
{
    /// <summary>
    /// Used for internal representation during parse of TNS names file
    /// </summary>
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + ",nq}")]
    public sealed class TnsNameNode
    {
        internal TnsNameNode([NotNull] string tnsName, [NotNull] TnsNamesParser.ParameterContext parameterContext)
        {
            TnsName = tnsName ?? throw new ArgumentNullException(nameof(tnsName));
            ParameterContext = parameterContext ?? throw new ArgumentNullException(nameof(parameterContext));
        }

        public TnsNamesParser.ParameterContext ParameterContext { get; }
        public string TnsName { get; }
        
        public string ServiceName { get; internal set; }
        public DatabaseAddressNode[] DatabaseAddresses { get; internal set; }

        private string DebuggerDisplay => TnsName;
    }
}