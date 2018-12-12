using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

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

        /// <summary>
        /// Searches all files within a specified directory. Finds all occurrences of a specified string within the files searched.
        /// Outputs all lines containing the specified string into specified destination file.
        /// Reports total files processed, number of lines where the specified string was found, and the
        /// number of occurrences of the specified string to the console.
        /// </summary>
        /// <param name="sourceDirectoryPath">Specified directory to search files within</param>
        /// <param name="searchString">Specified string to find within the files searched</param>
        /// <param name="destinationFilename">Specified file to output all lines containing the specified string searched for</param>
        public static void ProcessAndReportFiles(string sourceDirectoryPath, string searchString,
            string destinationFilename)
        {
            var numLinesFound = 0;
            var numOccurrences = 0;
            var filesInSourceDirectory = Directory.GetFiles(sourceDirectoryPath);
            var numFiles = filesInSourceDirectory.Length;
            var listOfFileInfo = filesInSourceDirectory.Select(fileName => ProcessFile(fileName, searchString, destinationFilename)).ToList();

            foreach (var tuple in listOfFileInfo)
            {
                numLinesFound += tuple.Item1;
                numOccurrences += tuple.Item2;
            }

            Console.WriteLine($"Total number of files searched: {numFiles}");
            Console.WriteLine($"Total number of lines containing the string searched for: {numLinesFound}");
            Console.WriteLine($"Total number of times the string searched occured: {numOccurrences}");
        }

        private static Tuple<int , int> ProcessFile(string fileName, string searchString, string destinationFilename)
        {
            return Task<Tuple<int,int>>.Factory.StartNew(() =>
            {
                var linesFound = new Collection<string>();
                var numLines = 0;
                var numOccurrences = 0;
                using (var reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!line.Contains(searchString)) continue;
                        linesFound.Add(line);
                        numLines += 1;
                        numOccurrences += Regex.Matches(line, searchString).Count;
                    }
                    reader.Close();
                }

                var writerLock = new ReaderWriterLockSlim();
                writerLock.EnterWriteLock();
                using (var writer = File.AppendText(destinationFilename))
                {
                    foreach (var line in linesFound)
                    {
                        writer.WriteLine(line);
                    }
                    writer.Close();
                }
                writerLock.ExitWriteLock();
                return new Tuple<int,int>(numLines, numOccurrences);
            }).Result;
        }
    }
}
