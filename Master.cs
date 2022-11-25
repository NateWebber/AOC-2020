using System;

public class Master
{
    public static void Main(string[] args)
    {
        switch (Int32.Parse(args[0]))
        {
            case 1:
                Day1.Run();
                break;
            case 2:
                Day2.Run();
                break;
            case 3:
                Day3.Run();
                break;
            case 4:
                Day4.Run();
                break;
            case 5:
                Day5.Run();
                break;
            case 6:
                Day6.Run();
                break;
            case 7:
                Day7.Run();
                break;
            case 8:
                Day8.Run();
                break;
            case 9:
                Day9.Run();
                break;
            default:
                Console.WriteLine("Invalid day \"{0}\" chosen", args[0]);
                break;
        }
    }
}
