using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

#pragma warning disable 1591 // Missing comments

namespace erl.Oracle.TnsNames.ANTLR
{
    public class TnsNamesListener : TnsNamesParserBaseListener
    {
        private TnsNameNode _currentTnsNameInfo;
        private string _currentTnsNameSid;
        private string _currentTnsNameServiceName;

        private List<DatabaseAddressNode> _currentTnsNameAddressList;
        private DatabaseAddressNode _currentDatabaseAddress;

        private readonly Stack<string> _levelStack = new Stack<string>();

        public TnsNamesListener()
        {
            ErrorNodes = new List<TnsNamesListenerErrorNode>();
            TnsItems = new List<TnsNameNode>();
            IfileEntries = new List<string>();
        }

        public List<TnsNamesListenerErrorNode> ErrorNodes { get; }
        public List<TnsNameNode> TnsItems { get; }
        public List<string> IfileEntries { get; }

        public override void ExitParameter(TnsNamesParser.ParameterContext context)
        {
            string keyword = context.keyword().GetText();

            bool isRootLevel = context.Parent is TnsNamesParser.Configuration_fileContext;

            // Verify and add TNS name
            if (isRootLevel && !string.Equals("IFILE", keyword, StringComparison.OrdinalIgnoreCase))
            {
                var nodeErrors = new List<TnsNamesListenerErrorNode>();

                // TNS name
                if (string.IsNullOrWhiteSpace(_currentTnsNameInfo.TnsName))
                {
                    nodeErrors.Add(new TnsNamesListenerErrorNode(context, TnsNamesParseError.MissingTnsName));
                }

                // Service name
                if (!string.IsNullOrWhiteSpace(_currentTnsNameServiceName))
                {
                    _currentTnsNameInfo.ServiceName = _currentTnsNameServiceName;
                }
                else if (!string.IsNullOrWhiteSpace(_currentTnsNameSid))
                {
                    _currentTnsNameInfo.ServiceName = _currentTnsNameSid;
                }
                else
                {
                    nodeErrors.Add(new TnsNamesListenerErrorNode(context, TnsNamesParseError.MissingServiceName));
                }

                // Verify database addresses, require at least on database address
                if (!_currentTnsNameAddressList.Any())
                {
                    nodeErrors.Add(new TnsNamesListenerErrorNode(context, TnsNamesParseError.NoDatabaseAddresses));
                }
                foreach (var databaseAddress in _currentTnsNameAddressList)
                {
                    // Protocol
                    if (string.IsNullOrWhiteSpace(databaseAddress.Protocol))
                    {
                        nodeErrors.Add(new TnsNamesListenerErrorNode(databaseAddress.ParameterContext, TnsNamesParseError.MissingProtocol));
                        continue;
                    }

                    if (string.Equals("TCP", databaseAddress.Protocol, StringComparison.OrdinalIgnoreCase)
                        || string.Equals("TCPS", databaseAddress.Protocol, StringComparison.OrdinalIgnoreCase)
                        || string.Equals("SDP", databaseAddress.Protocol, StringComparison.OrdinalIgnoreCase))
                    {
                        // Host
                        if (string.IsNullOrWhiteSpace(databaseAddress.Host))
                        {
                            nodeErrors.Add(new TnsNamesListenerErrorNode(databaseAddress.ParameterContext, TnsNamesParseError.MissingHost));
                        }

                        // Port
                        int port;
                        if (string.IsNullOrWhiteSpace(databaseAddress.PortStr))
                        {
                            nodeErrors.Add(new TnsNamesListenerErrorNode(databaseAddress.ParameterContext, TnsNamesParseError.MissingPort));
                        }
                        else if (!int.TryParse(databaseAddress.PortStr, NumberStyles.None, CultureInfo.InvariantCulture, out port))
                        {
                            nodeErrors.Add(new TnsNamesListenerErrorNode(databaseAddress.ParameterContext, TnsNamesParseError.InvalidPortString));
                        }
                        else if (port < 1 || port > 65535)
                        {
                            nodeErrors.Add(new TnsNamesListenerErrorNode(databaseAddress.ParameterContext, TnsNamesParseError.InvalidPortRange));
                        }
                        else
                        {
                            databaseAddress.PortNumber = port;
                        }
                    }
                    else if (string.Equals("IPC", databaseAddress.Protocol, StringComparison.OrdinalIgnoreCase))
                    {
                        // Key
                        if (string.IsNullOrWhiteSpace(databaseAddress.Key))
                        {
                            nodeErrors.Add(new TnsNamesListenerErrorNode(databaseAddress.ParameterContext, TnsNamesParseError.MissingKey));
                        }
                    }
                    else if (string.Equals("NMP", databaseAddress.Protocol, StringComparison.OrdinalIgnoreCase))
                    {
                        // Server
                        if (string.IsNullOrWhiteSpace(databaseAddress.Server))
                        {
                            nodeErrors.Add(new TnsNamesListenerErrorNode(databaseAddress.ParameterContext, TnsNamesParseError.MissingServer));
                        }

                        // Pipe
                        if (string.IsNullOrWhiteSpace(databaseAddress.Pipe))
                        {
                            nodeErrors.Add(new TnsNamesListenerErrorNode(databaseAddress.ParameterContext, TnsNamesParseError.MissingPipe));
                        }
                    }
                }

                // Add TNS name or alternativly error nodes
                if (!nodeErrors.Any())
                {
                    _currentTnsNameInfo.DatabaseAddresses = _currentTnsNameAddressList.ToArray();
                    TnsItems.Add(_currentTnsNameInfo);
                }
                else
                {
                    foreach (var nodeError in nodeErrors)
                    {
                        ErrorNodes.Add(nodeError);
                    }
                }

                // Release current resources
                _currentTnsNameSid = null;
                _currentTnsNameServiceName = null;
                _currentTnsNameInfo = null;
                _currentTnsNameAddressList = null;
                _currentDatabaseAddress = null;
            }

            base.ExitParameter(context);
        }

        public override void EnterScalarParameterValue(TnsNamesParser.ScalarParameterValueContext context)
        {
            var parameterContext = (TnsNamesParser.ParameterContext)context.Parent;
            string keyword = parameterContext.keyword().GetText();
            var text = context.scalar.content.Text;

            bool isRootLevel = parameterContext.Parent is TnsNamesParser.Configuration_fileContext;
            bool isConnectDataLevel = _levelStack.Any() && string.Equals("CONNECT_DATA", _levelStack.First());
            bool isAddressLevel = _levelStack.Any() && string.Equals("ADDRESS", _levelStack.First());

            if (isAddressLevel && string.Equals(keyword, "HOST", StringComparison.OrdinalIgnoreCase))
            {
                _currentDatabaseAddress.Host = text.ToUpperInvariant();
            }
            else if (isAddressLevel && string.Equals(keyword, "KEY", StringComparison.OrdinalIgnoreCase))
            {
                _currentDatabaseAddress.Key = text.ToUpperInvariant();
            }
            else if (isAddressLevel && string.Equals(keyword, "PIPE", StringComparison.OrdinalIgnoreCase))
            {
                _currentDatabaseAddress.Pipe = text.ToUpperInvariant();
            }
            else if (isAddressLevel && string.Equals(keyword, "PORT", StringComparison.OrdinalIgnoreCase))
            {
                _currentDatabaseAddress.PortStr = text;
            }
            else if (isAddressLevel && string.Equals(keyword, "PROTOCOL", StringComparison.OrdinalIgnoreCase))
            {
                _currentDatabaseAddress.Protocol = text.ToUpperInvariant();
            }
            else if (isAddressLevel && string.Equals(keyword, "SERVER", StringComparison.OrdinalIgnoreCase))
            {
                _currentDatabaseAddress.Server = text.ToUpperInvariant();
            }
            else if (isConnectDataLevel && string.Equals(keyword, "SERVICE_NAME", StringComparison.OrdinalIgnoreCase))
            {
                _currentTnsNameServiceName = text.ToUpperInvariant();
            }
            else if (isConnectDataLevel && string.Equals(keyword, "SID", StringComparison.OrdinalIgnoreCase))
            {
                _currentTnsNameSid = text.ToUpperInvariant();
            }
            else if (isRootLevel && string.Equals(keyword, "IFILE", StringComparison.OrdinalIgnoreCase))
            {
                string filepath = context.scalar.content.Text;

                // Fix UNC path (Oracle thingie: the two starting slashes are forwards in TNS names files - UNC uses backslash)
                if (filepath.StartsWith("//"))
                {
                    filepath = @"\\" + (filepath.Length > 2 ? filepath.Substring(2) : string.Empty);
                }
                IfileEntries.Add(filepath);
            }

            base.EnterScalarParameterValue(context);
        }

        public override void EnterParameterListParameterValue(TnsNamesParser.ParameterListParameterValueContext context)
        {
            var parameterContext = (TnsNamesParser.ParameterContext)context.Parent;
            string keyword = parameterContext.keyword().GetText();
            _levelStack.Push(keyword);


            bool isRootLevel = parameterContext.Parent is TnsNamesParser.Configuration_fileContext;

            // TNS name node
            if (isRootLevel && !string.Equals(keyword, "IFILE", StringComparison.OrdinalIgnoreCase))
            {
                _currentTnsNameInfo = new TnsNameNode(keyword.ToUpperInvariant(), parameterContext);
                _currentTnsNameAddressList = new List<DatabaseAddressNode>();
            }
            // Address node
            else if (string.Equals(keyword, "ADDRESS", StringComparison.OrdinalIgnoreCase))
            {
                _currentDatabaseAddress = new DatabaseAddressNode(parameterContext);
                _currentTnsNameAddressList.Add(_currentDatabaseAddress);
            }

            base.EnterParameterListParameterValue(context);
        }

        public override void ExitParameterListParameterValue(TnsNamesParser.ParameterListParameterValueContext context)
        {
            _levelStack.Pop();

            base.ExitParameterListParameterValue(context);
        }
    }
}