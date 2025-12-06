using System.Collections.Concurrent;
using System.Numerics;

namespace adventofcode;

public class Day5Part2Processor : IDayProcessor
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

            var sortedRanges = stacks.OrderBy(x => x[0]).ToList();

            List<(BigInteger Start, BigInteger End)> mergedRanges = [];

            foreach (var current in sortedRanges)
            {
                if (mergedRanges.Count == 0)
                {
                    mergedRanges.Add((current[0], current[1]));
                    continue;
                }

                int lastIndex = mergedRanges.Count - 1;
                var (Start, End) = mergedRanges[lastIndex];

                if (current[0] <= End + 1)
                {
                    if (current[1] > End)
                    {
                        mergedRanges[lastIndex] = (Start, current[1]);
                    }
                }
                else
                {
                    mergedRanges.Add((current[0], current[1]));
                }
            }

            foreach (var (start, end) in mergedRanges)
            {
                freshFood += end - start + 1;
            }

            Console.WriteLine($"Number of possible fresh food ids is {freshFood}");
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read for Day 5 Part 1:");
            Console.WriteLine(e.Message);
        }
    }
}
