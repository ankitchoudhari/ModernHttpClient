using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ModernHttpClient
{
    internal static class Utility
    {
        public static bool MatchHostnameToPattern(string hostname, string pattern)
        {
            
            string[] splitPattern = pattern.Split('*');

         
            if (splitPattern.Length == 1)
            {
                bool ret =  (String.Compare(hostname, pattern, true, CultureInfo.InvariantCulture) == 0);
                return ret;
            }
            
            if (splitPattern.Length == 2)
            {
                if (!splitPattern[1].StartsWith(".") && String.IsNullOrEmpty(splitPattern[1]))
                {
                    return false;
                }

            }

            if (splitPattern.Length == 3)
            {
                return false;
            }

            string regPattern = pattern.Replace("*", ".*");

            return Regex.IsMatch(hostname, regPattern, RegexOptions.IgnoreCase);

        }
    }
}
