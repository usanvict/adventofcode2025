namespace adventofcode;

public class DayProcessorFactory : IDayProcessorFactory
{
    public IDayProcessor GetDayProcessor(string day)
    {
        if (day == "Day1")
        {
            return new Day1Processor();
        }
        throw new ArgumentException($"No processor found for day: {day}");
    }
}