using System;
using System.Linq;

namespace erl.Oracle.TnsNames
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var rootFilesInfos = TnsNames.ResolveRootTnsNamesFiles();
                var allFiles = TnsNames.OpenTnsNamesFiles(rootFilesInfos, ignoreErrors: true, followIFileEntries: true);

                Console.WriteLine("### Resolved root TNS names files\n");
                foreach (var fileInfo in rootFilesInfos.OrderBy(f => f.Source).ThenBy(f => f.SourceOrder))
                {
                    Console.WriteLine("{0,-10} {1,2}: {2}", GetSourceName(fileInfo.Source), fileInfo.SourceOrder, fileInfo.Filepath);
                }

                Console.WriteLine("\n\n### Enumeration of TNS names");
                foreach (var tnsNamesFile in allFiles.OrderBy(f => f.Source).ThenBy(f => f.SourceOrder))
                {
                    // Write TNS names filepath and source
                    Console.WriteLine("\n{0}: {1}", GetSourceName(tnsNamesFile.Source), tnsNamesFile.Filepath);

                    foreach (var tns in tnsNamesFile.TnsNames.OrderBy(t => t.TnsName))
                    {
                        // Write TNS name and service name
                        Console.Write("\n   - {0,-20} {1,-10}", tns.TnsName, tns.ServiceName);

                        foreach (var databaseAddress in tns.DatabaseAddresses)
                        {
                            // Write protocol
                            Console.Write("{0,-4}", databaseAddress.Protocol);

                            // Write protocol specific information
                            var ipAddress = databaseAddress as IpDatabaseAddress;
                            var ipcAddress = databaseAddress as IpcDatabaseAddress;
                            var namedPipeAddress = databaseAddress as NamedPipeDatabaseAddress;

                            if (ipAddress != null)
                            {
                                Console.WriteLine("{0,5} {1,-15}", ipAddress.Port, ipAddress.Host);
                            }
                            else if (ipcAddress != null)
                            {
                                Console.WriteLine("{0,-15}", ipcAddress.Key);
                            }
                            else if (namedPipeAddress != null)
                            {
                                Console.WriteLine("{0,-15} {1,5}", namedPipeAddress.Server, namedPipeAddress.Pipe);
                            }
                            else
                            {
                                Console.WriteLine(databaseAddress.RawAddress); // fallback to raw parse representation
                            }

                            // Write identation for next iteration
                            Console.Write("{0,36}", ' ');
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.DumpException());
            }

            // given any argument: do not wait for exit
            if (!args.Any())
            {
                Console.WriteLine("\n\n\nPress any key to exit...");
                Console.ReadKey(true);
            }
        }

        private static string GetSourceName(TnsNamesSource source)
        {
            switch (source)
            {
                case TnsNamesSource.Unknown:
                    return "Unknown";
                case TnsNamesSource.TnsAdminEnvironmentVariable:
                    return "TNS_ADMIN";
                case TnsNamesSource.OracleHomeEnvironmentVariable:
                    return "ORACLE_HOME";
                case TnsNamesSource.PathEnvironmentVariable:
                    return "PATH";
                case TnsNamesSource.IfileEntry:
                    return "IFile";
                default:
                    return Enum.GetName(typeof (TnsNamesSource), source);
            }
        }
    }
}