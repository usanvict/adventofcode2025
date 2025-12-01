namespace adventofcode;

public class Day1Part1Processor : IDayProcessor
{
    public void ProcessFile(string dayPath, string selectedFile)
    {
        Console.WriteLine($"Processing Day 1 specific file: {selectedFile}");

        int startNumber = 50;
        int passwordNumber = 0;

        try
        {
            using StreamReader sr = new(Path.Combine(dayPath, selectedFile));
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Length >= 2 && int.TryParse(line.AsSpan(1), out int number))
                {
                    char action = line[0];
                    if (action == 'R')
                    {
                        Console.WriteLine($"Action: {action}, Number: {number}");
                        startNumber += number;
                        if (startNumber >= 100 || startNumber < 0)
                        {
                            startNumber = (startNumber % 100 + 100) % 100;
                        }
                    }
                    else if (action == 'L')
                    {
                        Console.WriteLine($"Action: {action}, Number: {number}");
                        startNumber -= number;
                        if (startNumber < 0 || startNumber >= 100)
                        {
                            startNumber = (startNumber % 100 + 100) % 100;
                        }
                    }
                    if (startNumber == 0)
                    {
                        passwordNumber += 1;
                    }

                }
            }
            Console.WriteLine($"The password number for Day 1 is: {passwordNumber}");
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read for Day 1:");
            Console.WriteLine(e.Message);
        }
    }
}