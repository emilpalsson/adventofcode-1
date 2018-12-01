using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    internal class Program
    {
        private static void Main()
        {
            var input = File.ReadAllLines("input.txt");
            var frequency = input.Aggregate(0, UpdateFrequency);

            Console.WriteLine($"The resulting frequency is {frequency}.");
            FindDuplicateFrequency(input);
            Console.ReadLine();
        }

        private static int UpdateFrequency(int currentFrequency, string frequencyChange)
        {
            var plusOrMinus = frequencyChange.Substring(0, 1);
            var number = int.Parse(frequencyChange.Substring(1));

            if (plusOrMinus == "+")
            {
                currentFrequency += number;
            }
            else
            {
                currentFrequency -= number;
            }

            return currentFrequency;
        }

        private static void FindDuplicateFrequency(string[] input)
        {
            var frequency = 0;
            var frequencies = new HashSet<int>();
            var hasDuplicate = false;
            var iteration = 0;

            while (!hasDuplicate)
            {
                iteration++;

                foreach (var frequencyChange in input)
                {
                    frequency = UpdateFrequency(frequency, frequencyChange);
                    hasDuplicate = !frequencies.Add(frequency);
                    if (hasDuplicate) break;
                }
            }
          
            Console.WriteLine($"The first duplicate frequency is {frequency} which was found after {iteration} iterations.");
        }
    }
}
