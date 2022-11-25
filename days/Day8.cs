using System;
using System.IO;
using System.Collections;
public class Day8
{
    static string? inFilePathA;
    static string? inFilePathB;

    static List<string> inputList = new List<string>();
    public static void Run()
    {
        Console.WriteLine("Day 8 Selected!"); //TODO UPDATE ME!
        inFilePathA = "inputs/Day8.txt"; //TODO UPDATE ME!
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
        Console.WriteLine("Day 8 Completed!"); //TODO UPDATE ME!
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
        HashSet<int> visitedInstructions = new HashSet<int>();
        int accumulator = 0;
        int pointer = 0;
        while (true)
        {
            //Console.WriteLine("visiting " + pointer);
            if (!(visitedInstructions.Add(pointer)))
                break;
            string[] currentInstruction = inputList[pointer].Split(" ");
            switch (currentInstruction[0])
            {
                case "acc":
                    int value = int.Parse(currentInstruction[1].Substring(1));
                    if (currentInstruction[1][0] == '+')
                    {
                        accumulator += value;
                    }
                    else
                    {
                        accumulator -= value;
                    }
                    pointer++;
                    break;
                case "jmp":
                    int offset = int.Parse(currentInstruction[1].Substring(1));
                    if (currentInstruction[1][0] == '+')
                    {
                        pointer += offset;
                    }
                    else
                    {
                        pointer -= offset;
                    }
                    break;
                case "nop":
                    pointer++;
                    break;
            }

        }
        Console.WriteLine("Part 1: {0}", accumulator);
    }

    private static void Part2(bool differentInput)
    {
        int finalAcc = 0;
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

        for (int i = 0; i < inputList.Count; i++)
        {
            string instruction = inputList[i];
            if (instruction.Contains("jmp"))
            {
                Console.WriteLine("swapping instruction {0} to nop", i);
                List<string> newList = new List<string>();
                foreach (string s in inputList)
                {
                    newList.Add((string)s.Clone());
                }
                newList[i] = "nop" + instruction.Substring(3);
                Console.WriteLine("THESE SHOULD BE DIFFERENT:");
                Console.WriteLine(newList[i]);
                Console.WriteLine(inputList[i]);
                (bool, int) result = doRun(newList);
                Console.WriteLine("result: " + result);
                if (result.Item1)
                {
                    finalAcc = result.Item2;
                    break;
                }

            }
            else if (instruction.Contains("nop"))
            {
                Console.WriteLine("swapping instruction {0} to jmp", i);
                List<string> newList = new List<string>();
                foreach (string s in inputList)
                {
                    newList.Add((string)s.Clone());
                }
                newList[i] = "jmp" + instruction.Substring(3);
                (bool, int) result = doRun(newList);
                if (result.Item1)
                {
                    finalAcc = result.Item2;
                    break;
                }
            }
        }

        Console.WriteLine("Part 2: {0}", finalAcc);
    }

    private static (bool, int) doRun(List<string> instructions)
    {
        HashSet<int> visitedInstructions = new HashSet<int>();
        int accumulator = 0;
        int pointer = 0;
        while (true)
        {
            //Console.WriteLine("visiting " + pointer);
            if (!(visitedInstructions.Add(pointer)))
                return (false, accumulator);
            if (pointer == instructions.Count)
                return (true, accumulator);
            string[] currentInstruction = instructions[pointer].Split(" ");
            switch (currentInstruction[0])
            {
                case "acc":
                    int value = int.Parse(currentInstruction[1].Substring(1));
                    if (currentInstruction[1][0] == '+')
                    {
                        accumulator += value;
                    }
                    else
                    {
                        accumulator -= value;
                    }
                    pointer++;
                    break;
                case "jmp":
                    int offset = int.Parse(currentInstruction[1].Substring(1));
                    if (currentInstruction[1][0] == '+')
                    {
                        pointer += offset;
                    }
                    else
                    {
                        pointer -= offset;
                    }
                    break;
                case "nop":
                    pointer++;
                    break;
            }
        }
    }
}