using System;
using System.Diagnostics;
using JetBrains.Annotations;

#pragma warning disable 1591 // Missing comments

namespace erl.Oracle.TnsNames.ANTLR
{
    /// <summary>
    /// Used for internal representation during parse of TNS names file
    /// </summary>
    [DebuggerDisplay("{TnsName,nq}")]
    public sealed class TnsNameNode
    {
        internal TnsNameNode([NotNull] string tnsName, [NotNull] TnsNamesParser.ParameterContext parameterContext)
        {
            if (tnsName == null) throw new ArgumentNullException("tnsName");
            if (parameterContext == null) throw new ArgumentNullException("parameterContext");

            TnsName = tnsName;
            ParameterContext = parameterContext;
        }

        public TnsNamesParser.ParameterContext ParameterContext { get; private set; }
        public string TnsName { get; private set; }
        
        public string ServiceName { get; internal set; }
        public DatabaseAddressNode[] DatabaseAddresses { get; internal set; }
    }
}