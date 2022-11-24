using System;
using System.IO;
using System.Collections;
using System.Text;
public class Day5
{
    static string? inFilePathA;
    static string? inFilePathB;

    static List<int>? seatIDList;
    public static void Run()
    {
        Console.WriteLine("Day 5 Selected!"); //TODO UPDATE ME!
        inFilePathA = "inputs/Day5.txt"; //TODO UPDATE ME!
        inFilePathB = null; //TODO EITHER UPDATE OR DELETE ME!
        seatIDList = new List<int>();
        Part1();
        if (inFilePathB == null)
        {
            Part2(false);
        }
        else
        {
            Part2(true);
        }
        Console.WriteLine("Day 5 Completed!"); //TODO UPDATE ME!
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
            int highestID = 0;
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                //Console.WriteLine(line);
                string rowString = line.Substring(0, 7);
                string columnString = line.Substring(7, 3);
                //Console.WriteLine("{0} - {1}", rowString, columnString);
                string rowBinaryString = "";
                string columnBinaryString = "";
                foreach (char c in rowString)
                {
                    if (c == 'F')
                    {
                        rowBinaryString += '0';
                    }
                    else
                    {
                        rowBinaryString += '1';
                    }
                }
                foreach (char c in columnString)
                {
                    if (c == 'L')
                    {
                        columnBinaryString += '0';
                    }
                    else
                    {
                        columnBinaryString += '1';
                    }
                }
                //Console.WriteLine("{0} - {1}", rowBinaryString, columnBinaryString);
                int thisID = (8 * (Convert.ToInt32(rowBinaryString, 2))) + (Convert.ToInt32(columnBinaryString, 2));
                //Console.WriteLine("{0} : {1}", line, thisID);
                if (thisID > highestID)
                    highestID = thisID;
                if (seatIDList != null)
                    seatIDList.Add(thisID);
            }
            Console.WriteLine("Part 1: {0}", highestID);
        }

    }

    private static void Part2(bool differentInput)
    {
        if (seatIDList != null)
        {
            seatIDList.Sort();

            for (int i = 0; i < seatIDList.Count - 1; i++)
            {
                if (seatIDList[i] + 2 == seatIDList[i + 1])
                {
                    Console.WriteLine("Part 2: {0}", seatIDList[i] + 1);
                    return;
                }
            }
        }

    }

}