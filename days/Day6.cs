using System;
using System.IO;
using System.Collections;
public class Day6
{
    static string? inFilePathA;
    static string? inFilePathB;

    static List<string> inputList = new List<string>();
    public static void Run()
    {
        Console.WriteLine("Day 6 Selected!"); //TODO UPDATE ME!
        inFilePathA = "inputs/Day6.txt"; //TODO UPDATE ME!
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
        Console.WriteLine("Day 6 Completed!"); //TODO UPDATE ME!
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
        int finalSum = 0;
        HashSet<char> groupSet = new HashSet<char>();
        foreach (string line in inputList)
        {
            if (line.Equals(""))
            {
                finalSum += groupSet.Count;
                groupSet = new HashSet<char>();
            }
            else
            {
                foreach (char c in line)
                {
                    groupSet.Add(c);
                }
            }
        }
        finalSum += groupSet.Count; //catch last set

        Console.WriteLine("Part 1: {0}", finalSum);
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
        int finalSum = 0;
        int groupMemberCount = 0;
        Dictionary<char, int> groupDict = new Dictionary<char, int>();
        foreach (string line in inputList)
        {
            if (line.Equals(""))
            {
                foreach (char key in groupDict.Keys)
                {
                    if (groupDict[key] == groupMemberCount)
                    {
                        finalSum++;
                    }
                }
                groupDict = new Dictionary<char, int>();
                groupMemberCount = 0;
            }
            else
            {
                foreach (char c in line)
                {
                    if (groupDict.ContainsKey(c))
                    {
                        groupDict[c] = groupDict[c] + 1;
                    }
                    else
                    {
                        groupDict[c] = 1;
                    }
                }
                groupMemberCount++;
            }
        }
        foreach (char key in groupDict.Keys)
        {
            if (groupDict[key] == groupMemberCount)
            {
                finalSum++;
            }
        }

        Console.WriteLine("Part 2: {0}", finalSum);
    }

}