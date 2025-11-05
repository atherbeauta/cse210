// CSE210 - Programming with Classes
// Author: Kazadi Athanase Muamba

using System;

class Program
{
    static void Main()
    {
        string response = "yes";

        while (response.ToLower() == "yes")
        {
            Random random = new Random();
            int magicNumber = random.Next(1, 101);

            int guess = -1;
            int count = 0;

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                count++;

                if (guess < magicNumber)
                    Console.WriteLine("Higher");
                else if (guess > magicNumber)
                    Console.WriteLine("Lower");
                else
                    Console.WriteLine($"You guessed it in {count} tries!");
            }

            Console.Write("Do you want to play again (yes/no)? ");
            response = Console.ReadLine();
        }
    }
}
