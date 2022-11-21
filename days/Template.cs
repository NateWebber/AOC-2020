using System;
using System.IO;
using System.Collections;
public class Template
{
    static string? inFilePathA;
    static string? inFilePathB;
    public static void Run()
    {
        Console.WriteLine("Day X Selected!"); //TODO UPDATE ME!
        inFilePathA = "inputs/X.txt"; //TODO UPDATE ME!
        inFilePathB = "inputs/X.txt"; //TODO EITHER UPDATE OR DELETE ME!
        Part1();
        if (inFilePathB == null)
        {
            Part2(false);
        }
        else
        {
            Part2(true);
        }
        Console.WriteLine("Day X Completed!"); //TODO UPDATE ME!
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
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
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
                    Console.WriteLine(line);
                }
            }
        }

    }

}