using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ModernHttpClient
{
    internal static class Utility
    {
        public static bool MatchHostnameToPattern(string hostname, string pattern)
        {

            // check if its a regular expression
            string[] splitPattern = pattern.Split('*');

            //it is not a pattern lets just do a case-insensitive check.
            if (splitPattern.Length == 1)
            {
                bool ret =  (String.Compare(hostname, pattern, true, CultureInfo.InvariantCulture) == 0);
                return ret;
            }

            // wild card character may be used as the left most name in the certificate unless this is the last char
            if (splitPattern.Length == 2)
            {
                if (!splitPattern[1].StartsWith(".") && String.IsNullOrEmpty(splitPattern[1]))
                {
                    return false;
                }

            }

            // can contain only one wild card
            if (splitPattern.Length == 3)
            {
                return false;
            }

            string regPattern = pattern.Replace("*", ".*");

            return Regex.IsMatch(hostname, regPattern, RegexOptions.IgnoreCase);

        }
    }
}
