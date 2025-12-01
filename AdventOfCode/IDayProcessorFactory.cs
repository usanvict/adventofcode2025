namespace adventofcode;

public interface IDayProcessorFactory
{
    IDayProcessor GetDayProcessor(string day, int part);
}