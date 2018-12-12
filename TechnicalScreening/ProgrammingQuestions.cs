using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechnicalScreening
{
    internal static class ProgrammingQuestions
    {
        /// <summary>
        /// Takes two strings and does the "perfect shuffle" with those two strings, alternating characters from the two input strings. 
        /// </summary>
        /// <param name="firstString">First character of this string will assume the first position in the string returned</param>
        /// <param name="secondString">First character of this string will take the second position in the string returned</param>
        /// <returns>String that is the product of the two parameters interleaved</returns>
        internal static string Interleave(string firstString, string secondString)
        {
            if (firstString == null && secondString == null)
                return null;
            if (firstString == null)
                return secondString;
            if (secondString == null)
                return firstString;

            int firstStringLength = firstString.Length, secondStringLength = secondString.Length;
            int count = 0;
            string finalString = null;
            List<char> finalStringChars = new List<char>();

            if (firstStringLength <= secondStringLength)
            {
                while (count < firstStringLength)
                {
                    finalStringChars.Add(firstString[count]);
                    finalStringChars.Add(secondString[count]);
                    ++count;
                }
                finalString = string.Concat(string.Join(null, finalStringChars.ToArray()), secondString.Substring(count));
            }
            else
            {
                while (count < secondStringLength)
                {
                    finalStringChars.Add(firstString[count]);
                    finalStringChars.Add(secondString[count]);
                    ++count;
                }
                finalString = string.Concat(string.Join(null, finalStringChars.ToArray()), firstString.Substring(count));
            }
            return finalString;
        }
    }
}
