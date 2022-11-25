using System;
using System.IO;
using System.Collections;
public class Day7
{
    static string? inFilePathA;
    static string? inFilePathB;

    static List<string> inputList = new List<string>();

    static Dictionary<string, Dictionary<string, int>> masterDictionary = new Dictionary<string, Dictionary<string, int>>();
    public static void Run()
    {
        Console.WriteLine("Day 7 Selected!"); //TODO UPDATE ME!
        inFilePathA = "inputs/Day7.txt"; //TODO UPDATE ME!
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
        Console.WriteLine("Day 7 Completed!"); //TODO UPDATE ME!
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
        int finalColorsCount = 0;
        /*
        * Idea: Master dictionary<bag color (string), contents dictionary<bag color (string), amount (int)>>
        */

        foreach (string line in inputList)
        {
            //Console.WriteLine("parsing instruction: " + line);
            Dictionary<string, int> contentDictionary = new Dictionary<string, int>();
            string[] containSplit = line.Split("contain");
            //striped orange bags contain 1 vibrant green bag, 5 plaid yellow bags, 1 drab magenta bag.
            containSplit[0] = containSplit[0].Trim();
            containSplit[1] = containSplit[1].Trim();
            string bagColor = containSplit[0].Split("bags")[0].Trim();
            //catch "base case" bags
            if (containSplit[1].Contains("no "))
            {
                contentDictionary["X"] = 0;
                masterDictionary[bagColor] = contentDictionary;
                continue;
            }
            //Console.WriteLine(containSplit[0].Split("bags")[0]);
            foreach (string contentString in containSplit[1].Split(","))
            {
                string trimmed = contentString.Trim();
                //Console.WriteLine("content string: " + contentString);
                string[] contentSplit = trimmed.Split(" ");

                int containsCount = int.Parse(contentSplit[0]);
                string containsColor = contentSplit[1] + " " + contentSplit[2];
                contentDictionary[containsColor] = containsCount;
            }
            masterDictionary[bagColor] = contentDictionary;
        }
        foreach (string bagColor in masterDictionary.Keys)
        {
            if (bagCanContainTarget(bagColor, "shiny gold", masterDictionary))
                finalColorsCount++;
        }
        Console.WriteLine("Part 1: {0}", finalColorsCount);
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
        Console.WriteLine("Part 2: {0}", calculateBagCount("shiny gold", masterDictionary));
    }

    private static bool bagCanContainTarget(string bagColor, string target, Dictionary<string, Dictionary<string, int>> masterDictionary)
    {
        Dictionary<string, int> currentDict = masterDictionary[bagColor];
        if (currentDict.ContainsKey("X"))
        {
            return false;
        }
        else if (currentDict.ContainsKey(target))
        {
            return true;
        }
        else
        {
            foreach (string key in currentDict.Keys)
            {
                if (bagCanContainTarget(key, target, masterDictionary))
                    return true;
            }
        }
        return false;
    }

    private static int calculateBagCount(string target, Dictionary<string, Dictionary<string, int>> masterDictionary)
    {
        int finalSum = 0;
        if (masterDictionary[target].ContainsKey("X")){
            return 0;
        }
        else{
            foreach (string key in masterDictionary[target].Keys){
                finalSum += masterDictionary[target][key];
                finalSum += (masterDictionary[target][key]) * calculateBagCount(key, masterDictionary);   
            }
        }
        return finalSum;
    }

}