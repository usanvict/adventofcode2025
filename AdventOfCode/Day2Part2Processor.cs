using System.Numerics;

namespace adventofcode;

public class Day2Part2Processor : IDayProcessor
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
                        int numberLength = number.Length;

                        for (int l = 2; l <= numberLength; l++)
                        {
                            if (numberLength % l == 0)
                            {
                                int dividedNumber = number.Length / l;

                                string firstPart = number[..dividedNumber];
                                bool allPartsEqual = true;
                                for (int p = 1; p < l; p++)
                                {
                                    string currentPart = number.Substring(p * dividedNumber, dividedNumber);
                                    if (currentPart != firstPart)
                                    {
                                        allPartsEqual = false;
                                        break;
                                    }
                                }

                                if (allPartsEqual)
                                {
                                    invalidNumbers += BigInteger.Parse(number);
                                    break;
                                }
                            }
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

    public static List<int> GetDivisors(int numberLength)
    {
        List<int> divisors = [];
        if (numberLength < 2) return divisors;

        for (int i = 2; i <= numberLength; i++)
        {
            if (numberLength % i == 0)
            {
                divisors.Add(i);
            }
        }
        return divisors;
    }
}
