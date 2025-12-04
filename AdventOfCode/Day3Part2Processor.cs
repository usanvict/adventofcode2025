using System.Numerics;
using System.Text;

namespace adventofcode;

public class Day3Part2Processor : IDayProcessor
{
    public void ProcessFile(string dayPath, string selectedFile)
    {
        Console.WriteLine($"Processing Day 3 specific file: {selectedFile}");

        try
        {
            using StreamReader sr = new(Path.Combine(dayPath, selectedFile));
            string? line;

            BigInteger maximumJoltageSum = 0;
            int numberOfBatteries = 12;

            while ((line = sr.ReadLine()) != null)
            {
                List<string> numberArray = [.. line.Select(c => c.ToString())];
                Console.WriteLine("Digits are : " + string.Join(", ", numberArray));

                StringBuilder maximumJoltage = new();

                int previousPosition = -1;
                for (int l = 0; l < numberOfBatteries; l++)
                {
                    int maxNextDigit = 0;
                    for (int j = previousPosition + 1; j < numberArray.Count - numberOfBatteries + maximumJoltage.Length + 1; j++)
                    {
                        Console.WriteLine($"Hledam {l + 1} cislici");
                        string nextDigit = numberArray[j];
                        //Console.WriteLine($"Considering digit {nextDigit} at position {j}");
                        if (maxNextDigit >= int.Parse(nextDigit))
                        {
                            continue;
                        }
                        maxNextDigit = int.Parse(nextDigit);
                        previousPosition = j;
                        Console.WriteLine($"New max {l + 1}th digit: {maxNextDigit} at position {j}");
                        // break;
                    }
                    Console.WriteLine($"Selected {l + 1}th digit: {maxNextDigit}");
                    maximumJoltage.Append(maxNextDigit);
                }
                maximumJoltageSum += BigInteger.Parse(maximumJoltage.ToString());
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
