using System.Collections.Concurrent;
using System.Numerics;

namespace adventofcode;

public class Day5Part1Processor : IDayProcessor
{
    public void ProcessFile(string dayPath, string selectedFile)
    {
        Console.WriteLine($"Processing Day 5 specific file: {selectedFile}");

        try
        {
            using StreamReader sr = new(Path.Combine(dayPath, selectedFile));
            string? line;

            List<List<BigInteger>> stacks = [];
            List<BigInteger> ids = [];

            bool emptyLine = false;
            BigInteger freshFood = 0;

            while ((line = sr.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    emptyLine = true;
                    continue;
                }

                if (!emptyLine)
                {
                    List<BigInteger> range = [.. line.Split("-")
                        .Select(s => s.Trim())
                        .Where(s => !string.IsNullOrWhiteSpace(s))
                        .Select(BigInteger.Parse)];

                    stacks.Add(range);
                }
                else
                {
                    ids.Add(BigInteger.Parse(line.Trim()));
                }
            }

            for (int i = 0; i < ids.Count; i++)
            {
                BigInteger id = ids[i];
                for (int j = 0; j < stacks.Count; j++)
                {
                    List<BigInteger> stack = stacks[j];
                    if (id >= stack[0] && id <= stack[1])
                    {
                        freshFood += 1;
                        break;
                    }
                }
            }
            Console.WriteLine($"Number of total fresh food items is {freshFood}");
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read for Day 5 Part 1:");
            Console.WriteLine(e.Message);
        }
    }
}
