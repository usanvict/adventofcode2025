namespace adventofcode;

public class DayProcessorFactory : IDayProcessorFactory
{
    public IDayProcessor GetDayProcessor(string day, int part)
    {
        if (day == "Day1")
        {
            if (part == 1)
            {
                return new Day1Part1Processor();
            }
            else if (part == 2)
            {
                return new Day1Part2Processor();
            }
        }
        throw new ArgumentException($"No processor found for day: {day} part: {part}");
    }
}