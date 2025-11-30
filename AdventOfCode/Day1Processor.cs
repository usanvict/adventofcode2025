using System;
using System.IO;

namespace adventofcode;

public class Day1Processor : IDayProcessor
{
    public void ProcessFile(string dayPath, string selectedFile)
    {
        Console.WriteLine($"Processing Day 1 specific file: {selectedFile}");

        try
        {
            using StreamReader sr = new StreamReader(Path.Combine(dayPath, selectedFile));
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine($"Day 1 specific processing: {line}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read for Day 1:");
            Console.WriteLine(e.Message);
        }
    }
}