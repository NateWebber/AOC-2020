using System;
using System.IO;
using System.Collections;
public class Day10
{
    static string? inFilePathA;
    static string? inFilePathB;

    static List<string> inputList = new List<string>();
    static int validArrangementCount = 0;
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
        continueRun(-1, 0, inputNumbers);
        Console.WriteLine($"Part 2: {validArrangementCount}");
    }

    private static void continueRun(int index, int currentValue, List<int> numberList)
    {
        //Console.WriteLine($"Continuing run at {index} with currentValue = {currentValue}");

        if (index == numberList.Count - 1)
        {
            //we made it to the end!
            //Console.WriteLine("This run made it to the end!");
            validArrangementCount++;
            return;
        }
        /* Reasoning: the list is sorted, so at most we will be considering the next three numbers (if they are consecutively +1, +2, and +3 to our current number */
        int threeForward = -1;
        int twoForward = -1;
        if (index < numberList.Count - 3)
        {
            threeForward = numberList[index + 3];
            twoForward = numberList[index + 2];
        }
        else if (index < numberList.Count - 2)
        {
            twoForward = numberList[index + 2];
        }
        int oneForward = numberList[index + 1];
        //Console.WriteLine($"considering oneForward - {oneForward}");
        if (oneForward <= currentValue + 3)
        {
            //Console.WriteLine($"oneForward ({oneForward}) <= currentValue + 3, continuing run...");
            continueRun(index + 1, oneForward, numberList);
        }
        //Console.WriteLine($"considering twoForward - {twoForward}");
        if (!(twoForward == -1) && twoForward <= currentValue + 3)
        {
            //Console.WriteLine($"twoForward ({twoForward}) <= currentValue + 3, continuing run...");

            continueRun(index + 2, twoForward, numberList);
        }
        //Console.WriteLine($"considering threeForward - {threeForward}");
        if (!(threeForward == -1) && threeForward <= currentValue + 3)
        {
            //Console.WriteLine($"threeForward ({threeForward}) <= currentValue + 3, continuing run...");
            continueRun(index + 3, threeForward, numberList);
        }
        return;
    }

}

/*

Original solution sucks, runtime untenable
Potential solution lies within the following insight (kinda mentioned in long comment above)

The list is sorted and has no duplicates, so if the number at index + 3 is exactly three greater than the current value,
then we know that there are three new potenetial routes, at index + 1, index + 2, index + 3

If at any point we're at a number, and the number at index + 1 is more than 3 larger than it, we are definitely hosed, since we can't make that leap
    
*/