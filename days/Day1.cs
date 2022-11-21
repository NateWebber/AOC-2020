using System;
using System.IO;
using System.Collections;
/* This one doesn't match the template because I wrote it before the template oops */
public class Day1
{
    public static void Run()
    {
        Console.WriteLine("Day 1 Selected!");
        Part1();
    }

    private static void Part1()
    {
        string inFilePath = "inputs/Day1.txt";
        List<int> inputList = new List<int>();
        using (StreamReader sr = File.OpenText(inFilePath))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                inputList.Add(int.Parse(line));
            }
        }
        inputList.Sort();
        for (int i = 0; i < inputList.Count; i++)
        {
            int a = inputList[i];
            if (a > 2020)
            {
                //admittedly we should't ever get here because we'll have missed the correct answer
                continue;
            }
            for (int j = i + 1; j < inputList.Count; j++)
            {
                int b = inputList[j];
                if (a + b == 2020)
                {
                    Console.WriteLine("Part 1: {0}", a * b);
                    return;
                }
            }
        }
    }
}