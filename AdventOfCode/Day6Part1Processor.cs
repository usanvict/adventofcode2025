using System.Numerics;

namespace adventofcode;

public class Day6Part1Processor : IDayProcessor
{
    public void ProcessFile(string dayPath, string selectedFile)
    {
        Console.WriteLine($"Processing Day 5 specific file: {selectedFile}");

        try
        {
            using StreamReader sr = new(Path.Combine(dayPath, selectedFile));
            string? line;

            List<List<string>> rows = [];
            BigInteger totalNumber = 0;

            while ((line = sr.ReadLine()) != null)
            {
                List<string> lineNumbers = [.. line.Split(' ', StringSplitOptions.RemoveEmptyEntries)];
                rows.Add(lineNumbers);
            }

            for (int i = 0; i < rows[0].Count; i++)
            {
                string operation = rows[^1][i];
                Console.WriteLine($"Operation for the column {i} is: {operation}");

                BigInteger currentColumnNumber = 0;
                Console.WriteLine($"Processing column {i}:");
                for (int j = 0; j < rows.Count - 1; j++)
                {
                    if (operation.Equals("+"))
                    {
                        Console.WriteLine($"Adding {rows[j][i]} to current total of {currentColumnNumber}");
                        currentColumnNumber += BigInteger.Parse(rows[j][i]);
                    }
                    else if (operation.Equals("*"))
                    {
                        if (j == 0)
                        {
                            currentColumnNumber = 1;
                        }
                        Console.WriteLine($"Multiplying {rows[j][i]} with current total of {currentColumnNumber}");
                        currentColumnNumber *= BigInteger.Parse(rows[j][i]);
                    }
                    Console.WriteLine($"Current total for column {i} is: {currentColumnNumber}");
                }
                Console.WriteLine($"Total for column {i} after all operations is: {currentColumnNumber}");
                totalNumber += currentColumnNumber;
            }
            Console.WriteLine($"The total number is: {totalNumber}");

        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read for Day 5 Part 1:");
            Console.WriteLine(e.Message);
        }
    }
}
