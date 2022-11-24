using System;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
public class Day4
{
    static string? inFilePathA;
    static string? inFilePathB;
    public static void Run()
    {
        Console.WriteLine("Day 4 Selected!"); //TODO UPDATE ME!
        inFilePathA = "inputs/Day4.txt"; //TODO UPDATE ME!
        inFilePathB = "inputs/Day4.txt"; //TODO EITHER UPDATE OR DELETE ME!
        Part1();
        if (inFilePathB == null)
        {
            Part2(false);
        }
        else
        {
            Part2(true);
        }
        Console.WriteLine("Day 4 Completed!"); //TODO UPDATE ME!
    }

    private static void Part1()
    {
        if (inFilePathA == null)
        {
            Console.WriteLine("ERROR PART 1: Input filepath was null");
            return;
        }
        int validCount = 0;
        string currentPassport = "";
        List<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();
        using (StreamReader sr = File.OpenText(inFilePathA))
        {
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Equals(""))
                {
                    currentPassport = currentPassport.Trim();
                    //Console.WriteLine("adding passport: ");
                    //Console.WriteLine(currentPassport);
                    passports.Add(StringToPassport(currentPassport));
                    currentPassport = "";
                }
                else
                {
                    currentPassport += (" " + line);
                }
            }
            if (!(currentPassport.Equals("")))
            {
                currentPassport = currentPassport.Trim();
                passports.Add(StringToPassport(currentPassport));
            }
        }
        foreach (Dictionary<string, string> passport in passports)
        {
            if (PassportIsValid(passport))
                validCount++;
            //Console.WriteLine();
        }
        Console.WriteLine("Part 1: {0}", validCount);

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
            int validCount = 0;
            string currentPassport = "";
            List<Dictionary<string, string>> passports = new List<Dictionary<string, string>>();
            using (StreamReader sr = File.OpenText(inFilePath))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Equals(""))
                    {
                        currentPassport = currentPassport.Trim();
                        //Console.WriteLine("adding passport: ");
                        //Console.WriteLine(currentPassport);
                        passports.Add(StringToPassport(currentPassport));
                        currentPassport = "";
                    }
                    else if (line[0] == '#')
                    {
                        Console.WriteLine("read comment, continuing");
                        continue;
                    }
                    else
                    {
                        currentPassport += (" " + line);
                    }
                }
                if (!(currentPassport.Equals("")))
                {
                    currentPassport = currentPassport.Trim();
                    passports.Add(StringToPassport(currentPassport));
                }
            }
            foreach (Dictionary<string, string> passport in passports)
            {
                if (PassportIsValidStrict(passport))
                    validCount++;
                Console.WriteLine();
            }
            Console.WriteLine("Part 2: {0}", validCount);

        }

    }

    private static Dictionary<string, string> StringToPassport(string passportString)
    {
        Dictionary<string, string> passport = new Dictionary<string, string>();
        string[] passportFields = passportString.Split(" ");
        foreach (string field in passportFields)
        {
            //Console.WriteLine("looking at field {0}", field);
            string[] fieldSplit = field.Split(":");
            passport.Add(fieldSplit[0], fieldSplit[1]);
        }
        return passport;
    }

    private static bool PassportIsValid(Dictionary<string, string> passport)
    {
        string[] requiredFields = {
            "byr", "eyr", "iyr", "hgt", "hcl", "ecl", "pid"
        };
        foreach (string field in requiredFields)
        {
            if (!(passport.ContainsKey(field)))
            {
                //Console.WriteLine("passport was missing {0}", field);
                return false;
            }

        }
        //Console.WriteLine("passport is valid");
        return true;
    }

    private static bool PassportIsValidStrict(Dictionary<string, string> passport)
    {
        string problems = "";
        bool isValid = true;
        Console.WriteLine("passport: {0}", PassportToString(passport));
        if (!(PassportIsValid(passport)))
        {
            //Console.WriteLine("passport didn't have required fields");
            problems += "field count, ";
            isValid = false;
            Console.WriteLine("failed field count");
            return false;
        }


        //byr check
        int birthYear = int.Parse(passport["byr"]);
        string yearRegex = "^[0-9]{4}$";
        if (!(Regex.IsMatch(passport["byr"], yearRegex)))
        {
            problems += "malformed birth year, ";
            isValid = false;
        }
        if (!(birthYear >= 1920 && birthYear <= 2002))
        {
            //Console.WriteLine("invalid birth year");
            problems += "birth year out of range, ";
            isValid = false;
        }


        //iyr check
        int issueYear = int.Parse(passport["iyr"]);
        if (!(Regex.IsMatch(passport["iyr"], yearRegex)))
        {
            problems += "malformed issue year, ";
            isValid = false;
        }
        if (!(issueYear >= 2010 && issueYear <= 2020))
        {
            problems += "issue year out of range, ";
            isValid = false;
        }

        //eyr check
        int exprYear = int.Parse(passport["eyr"]);
        if (!(Regex.IsMatch(passport["eyr"], yearRegex)))
        {
            problems += "malformed issue year, ";
            isValid = false;
        }
        if (!(exprYear >= 2020 && exprYear <= 2030))
        {
            problems += "expiration year out of range, ";
            isValid = false;
        }


        //hgt check
        string height = passport["hgt"];
        string heightUnit = height.Substring(height.Length - 2);
        if (!(heightUnit.Equals("in") || heightUnit.Equals("cm")))
        {
            problems += "invalid height unit, ";
            isValid = false;

        }
        string heightValueString = height.Substring(0, height.Length - 2); //might be a problem here
        string heightValueCMRegex = "^1[0-9]{2}$";
        string heightValueINRegex = "^[1-9][0-9]$";


        int heightValue = 0;
        if (!(heightValueString.Equals("")))
            heightValue = int.Parse(heightValueString);
        //Console.WriteLine("heightValue: {0}", heightValue);
        if (heightUnit.Equals("cm"))
        {
            if (!(Regex.IsMatch(heightValueString, heightValueCMRegex)))
            {
                problems += "malformed cm height value, ";
                isValid = false;
            }
            if (!(heightValue >= 150 && heightValue <= 193))
            {
                problems += "cm height out of range, ";
                isValid = false;
            }
        }
        else
        {
            if (!(Regex.IsMatch(heightValueString, heightValueINRegex)))
            {
                problems += "malformed in height value, ";
                isValid = false;
            }
            if (!(heightValue >= 59 && heightValue <= 76))
            {
                problems += "in height out of range, ";
                isValid = false;
            }
        }

        //hcl check
        string hairColor = passport["hcl"];
        string hairRegex = "^#[0-9a-f]{6}$";
        if (!(Regex.IsMatch(hairColor, hairRegex)))
        {
            problems += "invalid hair color, ";
            isValid = false;
        }

        //ecl check
        string[] validEcl = {
            "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
        };
        if (!(validEcl.Contains(passport["ecl"])))
        {
            problems += "invalid eye color, ";
            isValid = false;
        }

        //pid check
        string pidRegex = "^[0-9]{9}$";
        if (!(Regex.IsMatch(passport["pid"], pidRegex)))
        {
            problems += "invalid pid, ";
            isValid = false;

        }
        if (!isValid)
        {
            Console.WriteLine("problems: {0}", problems);
            return false;
        }
        Console.WriteLine("passport is valid!");
        return true;
    }

    private static string PassportToString(Dictionary<string, string> passport)
    {
        string retString = "";
        foreach (string key in passport.Keys)
        {
            retString += String.Format("{0}:{1} ", key, passport[key]);
        }
        return retString;
    }
}