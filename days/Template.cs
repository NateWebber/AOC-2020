using System;
using System.IO;
using System.Collections;
public class Template
{
    static string? inFilePathA;
    static string? inFilePathB;

    static List<string> inputList = new List<string>();
    public static void Run()
    {
        Console.WriteLine("Day X Selected!"); //TODO UPDATE ME!
        inFilePathA = "inputs/X.txt"; //TODO UPDATE ME!
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
        Console.WriteLine("Day X Completed!"); //TODO UPDATE ME!
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
        //DO STUFF HERE
    }

}