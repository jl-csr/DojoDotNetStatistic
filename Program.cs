using System;
using System.Collections.Generic;
using System.Linq;

namespace DojoDotNetStatistic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your favorite numbers separated by \",\":");

            var numbers = Console.ReadLine();
            var arrayOfNumbers = GetArray(numbers);

            if(arrayOfNumbers == null || !arrayOfNumbers.Any())
                return;

            arrayOfNumbers = arrayOfNumbers.OrderBy(o => o);

            Console.WriteLine("Results:");
            Console.WriteLine($"Minimum value: {arrayOfNumbers.FirstOrDefault()}");
            Console.WriteLine($"Maximum value: {arrayOfNumbers.LastOrDefault()}");
            Console.WriteLine($"Average: {arrayOfNumbers.Average()}");
            Console.WriteLine($"Total of numbers: {arrayOfNumbers.Count()}");

            Console.ReadKey();
        }

        public static IEnumerable<int> GetArray(string sentence)
        {
            var arrayOfNumbers = new List<int>();

            sentence.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
                    .ForEach(n => {

                        int converted;

                        if (!int.TryParse(n, out converted))
                        {
                            ShowError("Your sentence contains a non-numeric digit.");

                            arrayOfNumbers = null;

                            return;
                        }

                        arrayOfNumbers.Add(converted);
                    });

            return arrayOfNumbers;
        }

        public static void ShowError(string message)
        {
            var currentColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"Error: {message}");

            Console.ForegroundColor = currentColor;

        }
    }
}
