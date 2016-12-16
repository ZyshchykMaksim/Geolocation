using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkSphere
{
    public static class ExtensionMethods
    {
        public static string GetFirstLetter(this string str)
        {
            if (!String.IsNullOrWhiteSpace(str) && str.Length > 0)
            {
                return str.Substring(0, 1).ToUpper();
            }

            return str;
        }

        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}
