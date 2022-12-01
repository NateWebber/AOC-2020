using System;
using System.IO;
using System.Collections;
public class Day10
{
    static string? inFilePathA;
    static string? inFilePathB;

    static List<string> inputList = new List<string>();
    //static int validArrangementCount = 0;
    static long[] validRoutesCount = { };
    public static void Run()
    {
        Console.WriteLine("Day 10 Selected!"); //TODO UPDATE ME!
        inFilePathA = "inputs/Day10.txt"; //TODO UPDATE ME!
        inFilePathB = null; //TODO MAYBE UPDATE ME
        Part1();
        if (inFilePathB == null)
        {
            Part2(false);
        }
        else
        {
            Part2(true);
        }
        Console.WriteLine("Day 10 Completed!"); //TODO UPDATE ME!
    }

    private static void Part1()
    {
        if (inFilePathA == null)
        {
            Console.WriteLine("ERROR PART 1: Input filepath was null");
            return;
        }
        using (StreamReader sr = File.OpenText(inFilePathA))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                inputList.Add(line);
            }
        }
        //DO STUFF HERE
        List<int> inputNumbers = inputList.Select(int.Parse).ToList();
        inputNumbers.Sort();

        int oneDifferences = 0;
        int twoDifferences = 0;
        int threeDifferences = 0;
        int currentValue = 0;

        foreach (int i in inputNumbers)
        {
            if (i - currentValue == 1)
            {
                currentValue = i;
                oneDifferences++;
            }
            else if (i - currentValue == 2)
            {
                currentValue = i;
                twoDifferences++;
            }
            else if (i - currentValue == 3)
            {
                currentValue = i;
                threeDifferences++;
            }
            else
            {
                //uh oh
                Console.WriteLine("FOUND UNCROSSABLE GAP, PROGRAM FAILED");
                return;
            }
        }
        threeDifferences++; //include the final +3 for my device
        Console.WriteLine($"Part 1: {oneDifferences * threeDifferences}");
    }

    private static void Part2(bool differentInput)
    {
        if (differentInput)
        {
            inputList = new List<string>();
            if (inFilePathB == null)
            {
                Console.WriteLine("ERROR PART 2: Input filepath was null");
                return;
            }
            using (StreamReader sr = File.OpenText(inFilePathB))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    inputList.Add(line);
                }
            }
        }

        List<int> inputNumbers = inputList.Select(int.Parse).ToList();
        inputNumbers.Sort();
        inputNumbers.Add(inputNumbers[inputNumbers.Count() - 1] + 3);
        Console.WriteLine($"3 smallest numbers are: {inputNumbers[0]}, {inputNumbers[1]}, {inputNumbers[2]}"); //1, 2, 3
        validRoutesCount = new long[inputNumbers.Count()];
        validRoutesCount[0] = 1; //only ever one way to start
        validRoutesCount[1] = 2; //0, 2 or 0, 1, 2
        validRoutesCount[2] = 4; //0, 3 or 0, 1, 3 or 0, 2, 3 or 0, 1, 2, 3

        for (int i = 3; i < validRoutesCount.Count(); i++)
        {
            long thisTotal = 0;
            int currentNum = inputNumbers[i];
            if (inputNumbers[i - 3] + 3 >= currentNum)
            {
                thisTotal += validRoutesCount[i - 3];
            }
            if (inputNumbers[i - 2] + 3 >= currentNum)
            {
                thisTotal += validRoutesCount[i - 2];
            }
            if (inputNumbers[i - 1] + 3 >= currentNum)
            {
                thisTotal += validRoutesCount[i - 1];
            }
            validRoutesCount[i] = thisTotal;

        }

        Console.WriteLine($"Part 2: {validRoutesCount[validRoutesCount.Count() - 1]}");
    }



}

