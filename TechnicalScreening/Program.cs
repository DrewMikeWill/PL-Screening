using System;
using System.Runtime.InteropServices;

namespace TechnicalScreening
{
    class Program
    {
        static void Main(string[] args)
        {
            ProgrammingQuestions.ProcessAndReportFiles("E:\\Development\\PL\\TestDirectory", "test", "E:\\Development\\PL\\TestDirectory\\testOutput.txt");

            string firstTestString = ProgrammingQuestions.Interleave("abc", "12345");
            string secondTestString = ProgrammingQuestions.Interleave("abcdef", "123");
            string thirdTestString = ProgrammingQuestions.Interleave("abc", "123");
            string fourthTestString = ProgrammingQuestions.Interleave(null, "123");
            string fifthTestString = ProgrammingQuestions.Interleave("abc", null);
            string sixthTestString = ProgrammingQuestions.Interleave(null , null);
            Console.WriteLine(firstTestString);
            Console.WriteLine(secondTestString);
            Console.WriteLine(thirdTestString);
            Console.WriteLine(fourthTestString);
            Console.WriteLine(fifthTestString);
            Console.WriteLine(sixthTestString);
            Console.ReadKey();
        }
    }
}
