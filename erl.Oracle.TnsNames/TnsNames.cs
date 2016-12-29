using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using erl.Oracle.TnsNames.Antlr4.Runtime;
using erl.Oracle.TnsNames.Antlr4.Runtime.Tree;
using erl.Oracle.TnsNames.ANTLR;
using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    /// Functionality for resolving and opening Transparent Network Substrate (TNS) names files.
    /// </summary>
    [PublicAPI]
    public static class TnsNames
    {
        /// <summary>
        /// Resolves the available TNS names files.
        /// They are regarded as the root files as every TNS names file can have IFile entries
        /// pointing to other TNS names files.
        /// NOTE: Does not open the files (see OpenTnsNamesFile / OpenTnsNamesFiles).
        /// </summary>
        /// <returns></returns>
        public static TnsNamesFileInfo[] ResolveRootTnsNamesFiles()
        {
            var tnsAdminEnv = Environment.GetEnvironmentVariable("TNS_ADMIN");
            var oracleHomeEnv = Environment.GetEnvironmentVariable("ORACLE_HOME");
            var pathEnv = Environment.GetEnvironmentVariable("PATH");

            var result = new List<TnsNamesFileInfo>();

            if (!string.IsNullOrWhiteSpace(tnsAdminEnv) && FileExists(AppendPath(tnsAdminEnv, @"\tnsnames.ora")))
            {
                result.Add(new TnsNamesFileInfo(AppendPath(tnsAdminEnv, @"\tnsnames.ora"), TnsNamesSource.TnsAdminEnvironmentVariable));
            }

            if (!string.IsNullOrWhiteSpace(oracleHomeEnv) && FileExists(AppendPath(oracleHomeEnv, @"\network\admin\tnsnames.ora")))
            {
                result.Add(new TnsNamesFileInfo(AppendPath(oracleHomeEnv, @"\network\admin\tnsnames.ora"), TnsNamesSource.OracleHomeEnvironmentVariable));
            }

            if (!string.IsNullOrWhiteSpace(pathEnv))
            {
                int i = 1;
                result.AddRange(
                    from pathItem in pathEnv.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)    
                    where DirectoryExists(pathItem)
                    let path = JunctionPoint.Exists(pathItem) ? JunctionPoint.GetTarget(pathItem) : pathItem
                    let file = AppendPath(path, @"\..\network\admin\tnsnames.ora").ToLowerInvariant().Replace(@"\bin\..\", @"\")
                    where FileExists(file)
                    select new TnsNamesFileInfo(file, TnsNamesSource.PathEnvironmentVariable, sourceOrder: i++)
                    );
            }

            return result.ToArray();
        }


        /// <summary>
        /// Opens the TNS names files. May return additonal results due to IFile entries (recursively).
        /// </summary>
        /// <param name="tnsNamesFileInfos">The TNS names file information.</param>
        /// <param name="ignoreErrors">if set to <c>true</c> ignore files with parse errors.</param>
        /// <param name="followIFileEntries">if set to <c>true</c> followw IFile links.</param>
        /// <returns></returns>
        public static TnsNamesFile[] OpenTnsNamesFiles(IEnumerable<TnsNamesFileInfo> tnsNamesFileInfos, bool ignoreErrors, bool followIFileEntries)
        {
            return tnsNamesFileInfos.SelectMany(f => OpenTnsNamesFiles(f, ignoreErrors, followIFileEntries)).ToArray();
        }


        /// <summary>
        /// Opens the TNS names file. This API does not follow IFile entries.
        /// </summary>
        /// <param name="tnsNamesFileInfo">The TNS names file information.</param>
        /// <returns>Contents of TNS names file.</returns>
        /// <exception cref="erl.Oracle.TnsNames.TnsNamesParseException">TNS names file has errors.</exception>
        public static TnsNamesFile OpenTnsNamesFile([NotNull] TnsNamesFileInfo tnsNamesFileInfo)
        {
            TnsNamesListenerErrorNode[] errors;
            var result = OpenTnsNamesFileIncludeErrors(tnsNamesFileInfo, out errors);

            if (errors.Any())
            {
                throw new TnsNamesParseException("TNS names file has errors.")
                            .AddData("FILE", tnsNamesFileInfo.Filepath);
            }

            return result;
        }

        /// <summary>
        /// Opens the TNS names file. This API includes an error list.
        /// </summary>
        /// <param name="tnsNamesFileInfo">The TNS names file information.</param>
        /// <param name="errors">The error list.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">tnsNamesFileInfo</exception>
        public static TnsNamesFile OpenTnsNamesFileIncludeErrors([NotNull] TnsNamesFileInfo tnsNamesFileInfo, out TnsNamesListenerErrorNode[] errors)
        {
            if (tnsNamesFileInfo == null) throw new ArgumentNullException(nameof(tnsNamesFileInfo));

            var fileStream = new FileStream(tnsNamesFileInfo.Filepath, FileMode.Open);
            var inputStream = new AntlrInputStream(fileStream);
            var lexer = new TnsNamesLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new TnsNamesParser(commonTokenStream);

#if RELEASE
            lexer.ErrorListeners.Clear();
            parser.ErrorListeners.Clear();
#endif

            var listener = new TnsNamesListener();
            var walker = new ParseTreeWalker();
            var parse = parser.configuration_file();
            walker.Walk(listener, parse);

            // Convert internal representation to public API representation
            var tnsNames = from tnsNameNode in listener.TnsItems
                           let databaseAddressNodes = tnsNameNode.DatabaseAddresses
                           let databaseAddresses = databaseAddressNodes.Select(CreateDatabaseAddress).ToArray()
                           let rawDescription = tnsNameNode.ParameterContext.parameterValue().children[1].GetText().ToUpperInvariant()
                           select new TnsNameInfo(tnsNameNode.TnsName, rawDescription, tnsNameNode.ServiceName, databaseAddresses);

            var iFileEntries = listener.IfileEntries.Select(p => new TnsNamesFileInfo(p, TnsNamesSource.IfileEntry, tnsNamesFileInfo));

            errors = listener.ErrorNodes.ToArray();
            return new TnsNamesFile(tnsNamesFileInfo, iFileEntries.ToArray(), tnsNames.ToArray());
        }

        /// <summary>
        /// Opens the TNS names file. This API does follow IFile entries. May return multiple result due to IFile entries (recursively).
        /// </summary>
        /// <param name="tnsNamesFileInfo">The TNS names file information.</param>
        /// <param name="ignoreErrors">if set to <c>true</c> ignore files with parse errors.</param>
        /// <returns></returns>
        public static TnsNamesFile[] OpenTnsNamesFiles(TnsNamesFileInfo tnsNamesFileInfo, bool ignoreErrors)
        {
            return OpenTnsNamesFiles(tnsNamesFileInfo, ignoreErrors, true);
        }

        private static TnsNamesFile[] OpenTnsNamesFiles(TnsNamesFileInfo tnsNamesFileInfo, bool ignoreErrors, bool followIFileEntries)
        {
            var items = new List<TnsNamesFile>();


            var loopDetector = new HashSet<int>();
            var fileStack = new Stack<TnsNamesFileInfo>(new[] { tnsNamesFileInfo });
            while (fileStack.Count > 0)
            {
                var item = fileStack.Pop();

                var fileInfo = new FileInfo(item.Filepath.ToLowerInvariant());

                // Skip files that do not exist
                if (ignoreErrors && !FileExists(item.Filepath))
                {
                    continue;
                }

                // Loop detection amongst TNS names files
                int hashCode = fileInfo.FullName.GetHashCode();

                if (loopDetector.Contains(hashCode))
                {
                    continue;
                }

                loopDetector.Add(hashCode);

                // Open TNS names file
                try
                {
                    TnsNamesListenerErrorNode[] errors;
                    TnsNamesFile tnsNamesFile = OpenTnsNamesFileIncludeErrors(item, out errors);

                    items.Add(tnsNamesFile);

                    if (!ignoreErrors && errors.Any())
                    {
                        throw new TnsNamesParseException("TNS names file has errors.")
                            .AddData("FILE", tnsNamesFileInfo.Filepath);
                    }

                    if (followIFileEntries)
                    {
                        // Add IFile entries to stack
                        foreach (var iFile in tnsNamesFile.IfileEntries)
                        {
                            fileStack.Push(iFile);
                        }
                    }
                }
                catch (Exception e)
                {
                    if (!ignoreErrors)
                    {
                        throw new TnsNamesParseException("An error occured during parse.", e)
                            .AddData("FILE", tnsNamesFileInfo.Filepath);
                    }
                }
            }

            return items.ToArray();
        }

        private static IDatabaseAddress CreateDatabaseAddress(DatabaseAddressNode address)
        {
            var protocol = address.Protocol;
            var rawAddress = address.ParameterContext.GetText();

            if (string.Equals("TCP", protocol, StringComparison.OrdinalIgnoreCase)
                || string.Equals("TCPS", protocol, StringComparison.OrdinalIgnoreCase)
                || string.Equals("SDP", protocol, StringComparison.OrdinalIgnoreCase))
            {
                return new IpDatabaseAddress(protocol, address.Host, address.PortNumber, rawAddress);
            }
            if (string.Equals("IPC", protocol, StringComparison.OrdinalIgnoreCase))
            {
                return new IpcDatabaseAddress(protocol, address.Key, rawAddress);
            }
            if (string.Equals("NMP", protocol, StringComparison.OrdinalIgnoreCase))
            {
                return new NamedPipeDatabaseAddress(protocol, address.Server, address.Pipe, rawAddress);
            }
            
            return new UnknownDatabaseAddress(protocol, rawAddress);
        }

        /// <summary>
        /// Checks if a directory exists. On any error return false.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        private static bool DirectoryExists(string path)
        {
            try
            {
                return Directory.Exists(path);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a file exists. On any error return false. Return false on timeout.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns></returns>
        private static bool FileExists(string filepath)
        {
            try
            {
                var task = new Task<bool>(() =>
                {
                    try
                    {
                        return File.Exists(filepath);
                    }
                    catch
                    {
                        return false;
                    }
                });
                task.Start();
                return task.Wait(TimeSpan.FromMilliseconds(200)) && task.Result;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Appends string to a path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="str">The string to append.</param>
        /// <returns></returns>
        private static string AppendPath(string path, string str)
        {
            return path.TrimEnd('\\') + str;
        }
    }
}