using System;
using System.Collections.Generic;
using System.Diagnostics;

public static class StringExtensions
{
    public static string[] Split(this string str, char separator) //=> str.Split(separator);
    {
        try
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str), "Null String Error");
            }

            List<string> result = new List<string>();
            int startIndex = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == separator)
                {
                    if (i - startIndex > 0)
                    {
                        result.Add(str.Substring(startIndex, i - startIndex));
                    }
                    startIndex = i + 1;
                }
            }

            if (startIndex < str.Length)
            {
                result.Add(str.Substring(startIndex));
            }

            return result.ToArray();
        }
        catch (ArgumentNullException e)
        {
            Debug.Print($"Null String Error: {e.Message}");
            return new string[0];
        }
    }

    public static string ToLowerCase(this string str) => str.ToLower();

    public static string ToUpperCase(this string str) => str.ToUpper();
}