using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TechnicalScreening
{
    public static class ProgrammingQuestions
    {
        /// <summary>
        /// Takes two strings and does the "perfect shuffle" with those two strings, alternating characters from the two input strings. 
        /// </summary>
        /// <param name="firstString">First character of this string will assume the first position in the string returned</param>
        /// <param name="secondString">First character of this string will take the second position in the string returned</param>
        /// <returns>String that is the product of the two parameters interleaved</returns>
        public static string Interleave(string firstString, string secondString)
        {
            if ( string.IsNullOrEmpty(firstString) && string.IsNullOrEmpty(secondString))
                return null;
            if (string.IsNullOrEmpty(firstString))
                return secondString;
            if (string.IsNullOrEmpty(secondString))
                return firstString;
            
            var firstStringLength = firstString.Length;
            var secondStringLength = secondString.Length;
            var count = 0;
            var finalStringBuilder = new StringBuilder(firstStringLength + secondStringLength);

            if (firstStringLength <= secondStringLength)
            {
                while (count < firstStringLength)
                {
                    finalStringBuilder.Append(firstString[count]);
                    finalStringBuilder.Append(secondString[count]);
                    ++count;
                }
                finalStringBuilder.Append(secondString.Substring(count));
            }
            else
            {
                while (count < secondStringLength)
                {
                    finalStringBuilder.Append(firstString[count]);
                    finalStringBuilder.Append(secondString[count]);
                    ++count;
                }
                finalStringBuilder.Append( firstString.Substring(count));
            }

            var finalString = finalStringBuilder.ToString();
            return finalString;
        }

        public static void searchFiles(string sourceDirectoryPath, string searchString,
            string destinationFilename)
        {

        }
    }
}
