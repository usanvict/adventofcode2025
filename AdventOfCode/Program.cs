using System.IO;

namespace adventofcode;

internal static class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Available days:");

        string testInputsPath = "TestInputes";
        if (Directory.Exists(testInputsPath))
        {
            var days = Directory.GetDirectories(testInputsPath)
                                .Select(Path.GetFileName)
                                .Where(name => name != null)
                                .Select(name => name!)
                                .OrderBy(name => name)
                                .ToList();

            if (days.Count == 0)
            {
                Console.WriteLine("No days found. Exiting.");
                return;
            }

            for (int i = 0; i < days.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {days[i]}");
            }

            Console.WriteLine("\nChoose a day to process by entering the corresponding number:");


            string? daySelectionInput = Console.ReadLine();
            if (string.IsNullOrEmpty(daySelectionInput))
            {
                Console.WriteLine("Day selection cannot be empty. Exiting.");
                return;
            }


            if (!int.TryParse(daySelectionInput, out global::System.Int32 dayIndex) || dayIndex < 1 || dayIndex > days.Count)
            {
                Console.WriteLine("Invalid day selection. Exiting.");
                return;
            }


            string dayFolder = days[dayIndex - 1];
            string dayPath = Path.Combine(testInputsPath, dayFolder);

            if (Directory.Exists(dayPath))
            {
                Console.WriteLine($"\nSelected day: {dayFolder}");

                Console.WriteLine("\nAvailable files:");
                var files = Directory.GetFiles(dayPath)
                                     .Select(Path.GetFileName)
                                     .OrderBy(name => name)
                                     .ToList();

                if (files.Count == 0)
                {
                    Console.WriteLine("No files found for the selected day. Exiting.");
                    return;
                }

                for (int i = 0; i < files.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {files[i]}");
                }

                Console.WriteLine("\nChoose a file to process by entering the corresponding number:");
                string? fileSelectionInput = Console.ReadLine();
                if (string.IsNullOrEmpty(fileSelectionInput))
                {
                    Console.WriteLine("File selection cannot be empty. Exiting.");
                    return;
                }
                if (!int.TryParse(fileSelectionInput, out global::System.Int32 fileIndex) || fileIndex < 1 || fileIndex > files.Count)
                {
                    Console.WriteLine("Invalid selection. Exiting.");
                    return;
                }

                string selectedFile = files[fileIndex - 1] ?? string.Empty;
                if (string.IsNullOrEmpty(selectedFile))
                {
                    Console.WriteLine("Invalid file selection. Exiting.");
                    return;
                }

                IDayProcessorFactory factory = new DayProcessorFactory();
                IDayProcessor processor = factory.GetDayProcessor(dayFolder);
                processor.ProcessFile(dayPath, selectedFile);
            }
            else
            {

                Console.WriteLine("Invalid day selection. Exiting.");
                return;
            }
        }
        else
        {
            Console.WriteLine("No test inputs folder found.");
            return;
        }
    }
}