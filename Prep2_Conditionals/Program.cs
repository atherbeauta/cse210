// CSE210 - Programming with Classes
// Author: Kazadi Athanase Muamba

using System;

class Program
{
    static void Main()
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();
        int percent = int.Parse(input);

        string letter;

        if (percent >= 90) letter = "A";
        else if (percent >= 80) letter = "B";
        else if (percent >= 70) letter = "C";
        else if (percent >= 60) letter = "D";
        else letter = "F";

        Console.WriteLine($"Your grade is: {letter}");

        if (percent >= 70)
            Console.WriteLine("Congratulations! You passed!");
        else
            Console.WriteLine("Better luck next time!");
    }
}
