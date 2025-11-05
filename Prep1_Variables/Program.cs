// CSE210 - Programming with Classes
// Author: Kazadi Athanase Muamba

using System;

class Program
{
    static void Main()
    {
        Console.Write("What is your first name? ");
        string first = Console.ReadLine();

        Console.Write("What is your last name? ");
        string last = Console.ReadLine();

        Console.WriteLine($"\nYour name is {last}, {first} {last}.");
    }
}
