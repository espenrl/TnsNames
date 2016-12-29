using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace erl.Oracle.TnsNames
{
    /// <summary>
    /// Extensions method helpers for TNS names.
    /// </summary>
    [PublicAPI]
    public static class TnsNamesExtensions
    {
        /// <summary>
        /// Enumerates the TNS names.
        /// </summary>
        /// <param name="fileList">The TNS names files list.</param>
        /// <param name="ignoreDuplicateTnsNames">if set to <c>true</c> [ignore duplicates].</param>
        /// <returns></returns>
        public static IEnumerable<TnsNameInfo> EnumerateTnsNames(this IEnumerable<TnsNamesFile> fileList, bool ignoreDuplicateTnsNames = true)
        {
            if (ignoreDuplicateTnsNames)
            {
                return fileList.SelectMany(i => i.TnsNames).Distinct();
            }

            return fileList.SelectMany(i => i.TnsNames);
        }
    }
}