using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NAMESPACE
{
    internal static class StringExtensions
    {
        /// <summary>
        /// If source is null, returns string.empty. If not - returns it as is.
        /// </summary>
        public static string OrEmpty(this string source)
        {
            return source ?? string.Empty;
        }

        /// <summary>
        /// Returns true if target is equal to target in invariant culture and ignoring casing.
        /// </summary>
        public static bool EqIgnoreCase(this string source, string target)
        {
            return string.Equals(source, target, StringComparison.InvariantCultureIgnoreCase);
        }

        public static void WriteWholeArray(this Stream s, byte[] array)
        {
            s.Write(array, 0, array.Length);
        }
    }
}
