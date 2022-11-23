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
            default:
                Console.WriteLine("Invalid day \"{0}\" chosen", args[0]);
                break;
        }
    }
}
