using System.Numerics;

namespace adventofcode;

public class Day2Part1Processor : IDayProcessor
{
    public void ProcessFile(string dayPath, string selectedFile)
    {
        Console.WriteLine($"Processing Day 2 specific file: {selectedFile}");

        try
        {
            using StreamReader sr = new(Path.Combine(dayPath, selectedFile));
            string? line;

            BigInteger invalidNumbers = 0;

            while ((line = sr.ReadLine()) != null)
            {
                string[] ranges = line.Split(",");
                for (int k = 0; k < ranges.Length; k++)
                {
                    string[] rangeParts = ranges[k].Split("-");
                    BigInteger rangeStart = BigInteger.Parse(rangeParts[0]);
                    BigInteger rangeEnd = BigInteger.Parse(rangeParts[1]);
                    for (BigInteger i = rangeStart; i <= rangeEnd; i++)
                    {
                        string number = i.ToString();
                        int half = number.Length / 2;

                        string left = number[..half];
                        string right = number[half..];

                        if (left == right)
                        {
                            invalidNumbers += BigInteger.Parse(number);
                        }
                    }
                }
            }
            Console.WriteLine($"Total invalid numbers in line: {invalidNumbers}");
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read for Day 2:");
            Console.WriteLine(e.Message);
        }
    }
}
