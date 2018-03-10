using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

/*
 * PP 1.6: In C#, write a method that modifies a string using the following rules:
 *
    1. Each word in the input string is replaced with the following: the first letter of the word, the count of
    distinct letters between the first and last letter, and the last letter of the word. For example,
    “Automotive parts" would be replaced by "A6e p3s".

    2. A "word" is defined as a sequence of alphabetic characters, delimited by any non-alphabetic
    characters.

    3. Any non-alphabetic character in the input string should appear in the output string in its original
    relative location.
    We are looking for accuracy, efficiency and solution completeness. Please include this problem
    description in the comment at the top of your solution.
 */

namespace VinSolutionsChallenge
{
    class Program
    {
        private static string _defaultInput = "Automotive Parts";
        private static string _patternIsNotAlphabetic = "([^a-zA-Z'])";//
        private static string _patternIsAlphabetic = @"^[a-zA-Z]+$";
        static void Main(string[] args)
        {
            Console.Title = "VinSolutions/Cox Automotive Code Test";
            LoadInitialMessages();
            var input = Console.ReadLine();
            ExecuteTest(input);
        }

        private static void ExecuteTest(string input)
        {
            input = (input == string.Empty) ? _defaultInput : input;
            Console.WriteLine(string.Format("Executing method against '{0}'..." + Environment.NewLine, input));
            var splitInput = Regex.Split(input, _patternIsNotAlphabetic);
            var outputString = new StringBuilder();

            foreach (var str in splitInput)
            {
                if (Regex.IsMatch(str, _patternIsAlphabetic) && str.Length >= 2) //I wasn't sure how exactly to handle for single characters, so I figured I'd treat them as non-alphabetic and just append them in their place.
                {
                    var strToModify = str;
                    //Each word in the input string is replaced with: the first letter of the word, the count of distinct letters BETWEEN the first and last letter, and the last letter. For example: Automotive Parts should be A6e p3s
                    outputString.Append(strToModify.First()); //Add first letter.
                    outputString.Append(strToModify.Substring(1, strToModify.Length - 2).Distinct()
                        .Count()); //Add count of distinct letters between first and last letter.
                    outputString.Append(str.Last()); //Add last letter.
                }
                else
                {
                    outputString.Append(str);
                }
            }

            Console.WriteLine("Output: " + outputString);
            Console.WriteLine("Clear console and test another string? Y/N");
            var retest = Console.ReadKey();
            if (retest.Key == ConsoleKey.Y)
            {
                Console.Clear();
                LoadInitialMessages();
                ExecuteTest(Console.ReadLine());
            }
        }

        private static void LoadInitialMessages()
        {
            Console.WriteLine("Welcome, potential employers!");
            Console.WriteLine("Please input a string to modify. Alternatively, hit enter to execute with the input: 'Automotive Parts'" + Environment.NewLine);
        }

    }
}
