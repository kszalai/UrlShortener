using System;
using System.Text;

namespace UrlShortener.Converter
{
    public class UrlConverter
    {
        private readonly string BASE_62 = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Converts an int to base 62.
        /// <summary>
        /// <param name="n">Database ID</param>
        /// <returns>Base 62 String</returns>
        public string toBase62(int n)
        {
            StringBuilder sb = new StringBuilder();
            while (n != 0) {
                sb.Append(BASE_62[(n % 62)]);
                n = n / 62;
            }
            char[] reversedString = sb.ToString().ToCharArray();
            Array.Reverse(reversedString);

            return new string(reversedString);
        }

        /// <summary>
        /// Converts a base 62 string to an int
        /// </summary>
        /// <param name="s">Base 62 string</param>
        /// <returns>Database ID</returns>
        public int fromBase62(string s)
        {
            StringBuilder sb = new StringBuilder(s);
            char[] reversedString = sb.ToString().ToCharArray();
            Array.Reverse(reversedString);
            s = reversedString.ToString();
            int n = 0;
            for (int i = 0; i < s.Length; i++) {
                n += BASE_62.IndexOf(s[i]) * (int)Math.Pow(62.0, (double)i);
            }
            return n;
        }
    }
}