using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;

namespace adventofcode;

public class Day4Part1Processor : IDayProcessor
{
    public void ProcessFile(string dayPath, string selectedFile)
    {
        Console.WriteLine($"Processing Day 4 specific file: {selectedFile}");

        try
        {
            using StreamReader sr = new(Path.Combine(dayPath, selectedFile));
            string? line;

            List<List<char>> matrix = [];

            while ((line = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    matrix.Add([.. line.ToCharArray()]);
                }
            }

            int totalCount = 0;
            if (matrix.Count == 0 || matrix[0].Count == 0)
            {
                Console.WriteLine("Matrix is empty. No elements to process.");
                return;
            }

            int rows = matrix.Count;
            int cols = matrix[0].Count;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (matrix[r][c] == '@')
                    {
                        int adjacentAtCount = 0;
                        bool lessThanFourAdjacentAt = true;

                        for (int dr = -1; dr <= 1; dr++)
                        {
                            for (int dc = -1; dc <= 1; dc++)
                            {
                                if (dr == 0 && dc == 0) continue;

                                int newR = r + dr;
                                int newC = c + dc;

                                if (newR >= 0 && newR < rows && newC >= 0 && newC < cols && matrix[newR][newC] == '@')
                                {
                                    adjacentAtCount += 1;
                                    if (adjacentAtCount >= 4)
                                    {
                                        lessThanFourAdjacentAt = false;
                                        break;
                                    }

                                }
                            }
                            if (!lessThanFourAdjacentAt)
                            {
                                break;
                            }
                        }

                        if (lessThanFourAdjacentAt)
                        {
                            totalCount += 1;
                        }
                    }
                }
            }
            Console.WriteLine($"Total count of elements with less than 4 adjacent \'@\': {totalCount}");
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read for Day 4 Part 2:");
            Console.WriteLine(e.Message);
        }
    }
}
