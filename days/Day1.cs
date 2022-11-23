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
        Part2();
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
        for (int n = 0; n < inputList.Count; n++)
        {
            int a = inputList[n];
            if (a > 2020)
            {
                //admittedly we should't ever get here because we'll have missed the correct answer
                continue;
            }
            for (int m = n + 1; m < inputList.Count; m++)
            {
                int b = inputList[m];
                if (a + b == 2020)
                {
                    Console.WriteLine("Part 1: {0}", a * b);
                    //return;
                }
            }
        }
        /* O(n) solution I found here 
        https://codereview.stackexchange.com/questions/205696/determine-a-list-contains-two-elements-with-a-given-sum
        */
        Console.WriteLine("trying O(n)");
        HashSet<int> theSet = new HashSet<int>();
        int expectedSum = 2020;
        foreach (int x in inputList)
        {
            if (theSet.Contains(expectedSum - x))
            {
                Console.WriteLine("Part 1 but O(n): {0}", x * (expectedSum - x));
            }
            else
            {
                theSet.Add(x);
                //Console.WriteLine("set contents:");
                //Console.WriteLine(theSet.ToString());
            }
        }
        return;
    }

    /*Kind of just rehashing that O(n) Part 1 trick, but obviously additional complexity for considering three numbers*/
    private static void Part2()
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
        foreach (int x in inputList)
        {
            int expectedSum = (2020 - x);
            HashSet<int> theSet = new HashSet<int>();
            foreach (int y in inputList)
            {
                if (theSet.Contains(expectedSum - y))
                {
                    Console.WriteLine("Part 2: {0}", (x * y * (expectedSum - y)));
                    return; //if i don't add this return line it prints the result 3 times. is that interesting? maybe
                }
                else
                {
                    theSet.Add(y);
                }
            }
        }
        return;
    }
}