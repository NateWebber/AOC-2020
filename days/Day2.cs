using System;
using System.IO;
using System.Collections;
public class Day2
{
    static string? inFilePathA;
    static string? inFilePathB;
    public static void Run()
    {
        Console.WriteLine("Day 2 Selected!"); //TODO UPDATE ME!
        inFilePathA = "inputs/Day2.txt"; //TODO UPDATE ME!
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
        Console.WriteLine("Day 2 Completed!"); //TODO UPDATE ME!
    }

    private static void Part1()
    {
        if (inFilePathA == null)
        {
            Console.WriteLine("ERROR PART 1: Input filepath was null");
            return;
        }
        List<int> inputList = new List<int>();
        using (StreamReader sr = File.OpenText(inFilePathA))
        {
            int validCount = 0;
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                if (ProcessLine(line))
                {
                    validCount++;
                }
            }
            Console.WriteLine("Part 1: {0}", validCount);
        }

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
            List<int> inputList = new List<int>();
            using (StreamReader sr = File.OpenText(inFilePath))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                }
            }
        }

    }

    private static bool ProcessLine(string line)
    {
        string[] lineSplit = line.Split(":");
        string password = lineSplit[1].Trim();
        string[] criteriaSplit = lineSplit[0].Split(" ");
        char criteriaChar = criteriaSplit[1][0];
        string[] numsSplit = criteriaSplit[0].Split("-");
        return PasswordIsValid(password, (criteriaChar, int.Parse(numsSplit[0]), int.Parse(numsSplit[1])));
    }
    private static bool PasswordIsValid(string password, (char, int, int) criteria)
    {
        int charCount = 0;
        foreach (char c in password)
        {
            if (c == criteria.Item1)
            {
                charCount++;
            }
        }
        if (criteria.Item2 <= charCount && charCount <= criteria.Item3)
        {
            return true;
        }
        return false;
    }
}