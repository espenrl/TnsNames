using System.Diagnostics;

#pragma warning disable 1591 // Missing comments

namespace erl.Oracle.TnsNames.ANTLR
{
    /// <summary>
    /// Used for internal representation during parse of TNS names file
    /// </summary>
    [DebuggerDisplay("{Protocol,nq}: {Host,nq}: {PortStr}")]
    public sealed class DatabaseAddressNode
    {
        public DatabaseAddressNode(TnsNamesParser.ParameterContext parameterContext)
        {
            ParameterContext = parameterContext;
        }

        public TnsNamesParser.ParameterContext ParameterContext { get; private set; }

        public string Host { get; internal set; }
        public string Key { get; internal set; }
        public string Pipe { get; internal set; }
        public string Protocol { get; internal set; }
        public int PortNumber { get; internal set; }
        public string PortStr { get; internal set; }
        public string Server { get; internal set; }
    }
}