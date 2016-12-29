using System;
using System.Diagnostics;
using JetBrains.Annotations;

#pragma warning disable 1591 // Missing comments

namespace erl.Oracle.TnsNames.ANTLR
{
    /// <summary>
    /// Used for internal representation during parse of TNS names file
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public sealed class TnsNameNode
    {
        internal TnsNameNode([NotNull] string tnsName, [NotNull] TnsNamesParser.ParameterContext parameterContext)
        {
            if (tnsName == null) throw new ArgumentNullException(nameof(tnsName));
            if (parameterContext == null) throw new ArgumentNullException(nameof(parameterContext));

            TnsName = tnsName;
            ParameterContext = parameterContext;
        }

        public TnsNamesParser.ParameterContext ParameterContext { get; }
        public string TnsName { get; }
        
        public string ServiceName { get; internal set; }
        public DatabaseAddressNode[] DatabaseAddresses { get; internal set; }

        private string DebuggerDisplay => TnsName;
    }
}