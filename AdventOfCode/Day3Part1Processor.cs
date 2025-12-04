using Microsoft.VisualBasic;
using System.Linq;

namespace adventofcode;

public class Day3Part1Processor : IDayProcessor
{
    public void ProcessFile(string dayPath, string selectedFile)
    {
        Console.WriteLine($"Processing Day 3 specific file: {selectedFile}");

        try
        {
            using StreamReader sr = new(Path.Combine(dayPath, selectedFile));
            string? line;

            int maximumJoltageSum = 0;

            while ((line = sr.ReadLine()) != null)
            {
                List<string> numberArray = [.. line.Select(c => c.ToString())];

                int maxFirstDigit = 0;
                int maximumJoltage = 0;

                for (int i = 0; i < numberArray.Count - 1; i++)
                {
                    if (maxFirstDigit > int.Parse(numberArray[i]))
                    {
                        continue;
                    }
                    maxFirstDigit = int.Parse(numberArray[i]);

                    for (int j = i + 1; j < numberArray.Count; j++)
                    {
                        string firstDigit = numberArray[i];
                        string secondDigit = numberArray[j];
                        int newNumber = int.Parse(firstDigit + secondDigit);
                        if (newNumber > maximumJoltage)
                        {
                            maximumJoltage = newNumber;
                        }
                    }
                }
                maximumJoltageSum += maximumJoltage;
            }
            Console.WriteLine($"Overall maximum joltage sum: {maximumJoltageSum}");
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read for Day 1:");
            Console.WriteLine(e.Message);
        }
    }
}
