namespace adventofcode;

public class DayProcessorFactory : IDayProcessorFactory
{
    public IDayProcessor GetDayProcessor(string day, int part)
    {
        return day switch
        {
            "Day1" => part switch
            {
                1 => new Day1Part1Processor(),
                2 => new Day1Part2Processor(),
                _ => throw new ArgumentException($"Invalid part for Day 1: {part}")
            },
            "Day2" => part switch
            {
                1 => new Day2Part1Processor(),
                2 => new Day2Part2Processor(),
                _ => throw new ArgumentException($"Invalid part for Day 2: {part}")
            },
            "Day3" => part switch
            {
                1 => new Day3Part1Processor(),
                2 => new Day3Part2Processor(),
                _ => throw new ArgumentException($"Invalid part for Day 3: {part}")
            },
            "Day4" => part switch
            {
                1 => new Day4Part1Processor(),
                2 => new Day4Part2Processor(),
                _ => throw new ArgumentException($"Invalid part for Day 4: {part}")
            },
            "Day5" => part switch
            {
                1 => new Day5Part1Processor(),
                2 => new Day5Part2Processor(),
                _ => throw new ArgumentException($"Invalid part for Day 4: {part}")
            },
            _ => throw new ArgumentException($"No processor found for day: {day} part: {part}")
        };
    }
}