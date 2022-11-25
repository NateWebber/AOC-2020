using System;
using System.IO;
using System.Collections;
public class Day9
{
    static string? inFilePathA;
    static string? inFilePathB;

    static List<string> inputList = new List<string>();
    static List<long> buffer = new List<long>();

    static int BUFFER_SIZE = 26; //one larger than what it technically is bc i'm too lazy to fix
    static long firstBadNumber = 0;

    public static void Run()
    {
        Console.WriteLine("Day 9 Selected!"); //TODO UPDATE ME!
        inFilePathA = "inputs/Day9.txt"; //TODO UPDATE ME!
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
        Console.WriteLine("Day 9 Completed!"); //TODO UPDATE ME!
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
        for (int i = 0; i < BUFFER_SIZE; i++)
        {
            buffer.Add(long.Parse(inputList[i]));
        }
        for (int i = BUFFER_SIZE; i < inputList.Count; i++)
        {
            buffer.RemoveAt(0);
            buffer.Add(long.Parse(inputList[i]));
            if (!numberIsValid())
            {
                firstBadNumber = buffer[BUFFER_SIZE - 1];
                break;
            }

        }
        Console.WriteLine("Part 1: {0}", firstBadNumber);

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
        long smallest = 0;
        long largest = 0;
        for (int i = 0; i < inputList.Count; i++)
        {
            long sum = long.Parse(inputList[i]);
            smallest = sum;
            largest = sum;
            bool found = false;
            //Console.WriteLine("starting at {0}", inputList[i]);
            int j = i + 1;
            while (sum <= firstBadNumber)
            {
                if (sum == firstBadNumber)
                {
                    found = true;
                    break;
                }
                long nextNumber = long.Parse(inputList[j]);
                if (nextNumber < smallest)
                    smallest = nextNumber;
                if (nextNumber > largest)
                    largest = nextNumber;
                sum += nextNumber;
                //Console.WriteLine("sum is {0} after adding {1}", sum, long.Parse(inputList[j]));
                j++;
            }
            if (found)
                break;

        }
        //Console.WriteLine("{0} | {1}", smallest, largest);
        Console.WriteLine("Part 2: {0}", smallest + largest);
    }

    private static bool numberIsValid()
    {
        long target = buffer[BUFFER_SIZE - 1];
        HashSet<long> theSet = new HashSet<long>();
        for (int i = 0; i < BUFFER_SIZE - 1; i++)
        {
            if (theSet.Contains(target - buffer[i]))
            {
                return true;
            }
            theSet.Add(buffer[i]);
        }
        return false;
    }
}