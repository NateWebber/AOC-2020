using System;
using System.IO;
using System.Collections;
public class Day3
{
    static string? inFilePathA;
    static string? inFilePathB;
    public static void Run()
    {
        Console.WriteLine("Day 3 Selected!"); //TODO UPDATE ME!
        inFilePathA = "inputs/Day3.txt"; //TODO UPDATE ME!
        inFilePathB = null; //TODO EITHER UPDATE OR DELETE ME!
        Part1();
        if (inFilePathB == null)
        {
            Part2(false);
        }
        else
        {
            Part2(true);
        }
        Console.WriteLine("Day 3 Completed!"); //TODO UPDATE ME!
    }

    private static void Part1()
    {
        if (inFilePathA == null)
        {
            Console.WriteLine("ERROR PART 1: Input filepath was null");
            return;
        }
        List<string> slope = new List<string>();
        using (StreamReader sr = File.OpenText(inFilePathA))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
                slope.Add(line);
        }
        Console.WriteLine("Part 1: {0}", DoRun(slope, 3, 1));
    }

    private static void Part2(bool differentInput)
    {
        string? inFilePath = inFilePathA;
        if (differentInput)
        {
            inFilePath = inFilePathB;
        }
        if (inFilePath == null)
        {
            Console.WriteLine("ERROR PART 2: Input filepath was null");
        }
        else
        {
            List<string> slope = new List<string>();
            using (StreamReader sr = File.OpenText(inFilePath))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    slope.Add(line);
                }
            }
            long finalTotal = 1;
            (int, int)[] angles = {
                (1, 1), (3, 1), (5, 1), (7, 1), (1, 2)
            };
            foreach ((int, int) angle in angles)
            {
                finalTotal = finalTotal * DoRun(slope, angle.Item1, angle.Item2);
            }
            Console.WriteLine("Part 2: {0}", finalTotal);
        }

    }

    private static int DoRun(List<string> slope, int xOffset, int yOffset)
    {
        int currentX = 0;
        int treesHit = 0;
        int lineLength = slope[0].Length;
        for (int i = 0; i < slope.Count; i += yOffset)
        {
            string currentLine = slope[i];
            if (currentLine[currentX] == '#')
                treesHit++;
            currentX += xOffset;
            if (currentX >= lineLength)
                currentX -= lineLength;
        }
        return treesHit;
    }

}